using System;
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

            int count = 0;
            string rid, tag;
            DocumentReference roomRef = db.Collection("rooms").Document("rid");
            DocumentSnapshot snapshot;
            while (count++ < 100) //to make risk free 
            {
                tag = GetRandomString();
                rid = room.Name + "#" + tag;
                roomRef = db.Collection("rooms").Document(rid);
                snapshot = await roomRef.GetSnapshotAsync();
                if (snapshot.Exists == false)
                {
                    room.id = tag;
                    await roomRef.SetAsync(room);
                    program.CU.RoomsTeacher.Add(room);
                    //update(Program.CU)
                    return true;
                }
            }
            return false;
        }
        public static async Task<bool> CreateUserfs(classes.User user)
        {
            Init();
            int count = 0;
            string sid, tag;

            DocumentReference roomRef;
            DocumentSnapshot snapshot;

            while (count++ < 100) //to make risk free 
            {
                tag = GetRandomString();
                sid = user.user_name;
                roomRef = db.Collection("users").Document(sid);
                snapshot = await roomRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    return false;
                }
                else
                {
                    user.tag = tag;
                    await roomRef.SetAsync(user);
                    //program.CU.RoomsTeacher.Add(user) ;
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
        public static async void Signup(string id, string pass)
        {   //adds user to db

        }
        public static string GetRandomString(int stringLength = 4)
        {
            StringBuilder sb = new StringBuilder();
            int numGuidsToConcat = (((stringLength - 1) / 32) + 1);
            for (int i = 1; i <= numGuidsToConcat; i++)
            {
                sb.Append(Guid.NewGuid().ToString("N"));
            }

            return sb.ToString(0, stringLength);
        }

    }
}


