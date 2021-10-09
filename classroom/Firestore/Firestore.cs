﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace classroom.Firestore
{
    public static class Firestore
    {
        public static EventHandler userexisnt;

        public static FirestoreDb db;
        public static void Init()
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "classroomt.json");
            db = FirestoreDb.Create("classroomt-f83c6");
        }
        //public static classes.Room GetRoom(string roomcode)
        //{
        //    DocumentReference roomdoc = db.Collection("rooms").Document(roomcode);

        //}
        
        public static async Task<bool> AddStudentfs(classes.User user, string rid)
        {
            DocumentReference userref = db.Collection("users").Document(user.user_name);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists) //user exist
            {
                DocumentReference roomref = db.Collection("rooms").Document(rid);
                DocumentSnapshot roomsnapshot = await userref.GetSnapshotAsync();
                classes.Room temp = roomsnapshot.ConvertTo<classes.Room>();
                temp.students.Add(user);
                return true;

            }
                return false;
        }
        public static async Task<bool> CreateRoom(classes.Room room)
        {
            Random ran = new Random();
            StringBuilder sb = new StringBuilder("    ");
            int count = 0;
            string rid;
            DocumentReference roomRef = db.Collection("rooms").Document("rid");
            DocumentSnapshot snapshot;
            while (count++ < 100) //to make risk free 
            {
                for (int i = 0; i < 4; i++)
                {
                    sb[i] = (char)ran.Next('A', 'Z');
                }
                rid = room.id + "#" + sb.ToString();
                roomRef = db.Collection("rooms").Document("rid");
                snapshot = await roomRef.GetSnapshotAsync();
                if (snapshot.Exists == false)
                {
                    room.id = rid;
                    await roomRef.SetAsync(room);
                    program.CU.roomsTeacher.Add(room);
                    //update(Program.CU)
                    return true;
                }
            }
            return false;
        }
        public static async Task<classes.User> GetUserAsync(string id)
        {
            DocumentReference userref = db.Collection("users").Document(id);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<classes.User>();
            }
            else
            {
                return null;
            }
        }
        public static async Task<classes.User> AuthUser(string id, string pass)
        {   //easy authentication and returns current user if exists
            DocumentReference userref = db.Collection("users").Document(id);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                Dictionary<string, object> userdoc = snapshot.ToDictionary();
                if ((string)userdoc["password"] == pass)
                {
                    return snapshot.ConvertTo<classes.User>();
                }
            }
            return null;
        }
    }
}


