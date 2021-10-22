﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classroom.classes;
using classroom.Firestore;
using Google.Cloud.Firestore;

namespace classroom
{

    public static class program
    {
        public static User CU;
        public static event EventHandler<string> status;

        static program()
        {
            Firestore.Firestore.Init();
            CU = new User
            {
                RoomsStudentRef = new ArrayList(),
                RoomsTeacherRef = new ArrayList()
            };
        }


        public static bool UserSignup(string _username, string _password/*Argument*/)
        {

            //create new user object
            User newUser = new User
            {
                user_name = _username,
                password = _password

            };
            var res = Task.Run(async () =>
               await Firestore.Firestore.CreateUserfs(newUser)).Result;
            //put it in fs

            return res;



        }

        public static async Task<Room> ShowClass(string nameT)
        {
            Room Loadedroom;
            if (User.RoomsStudent.ContainsKey(nameT))
            {
                return User.RoomsStudent[nameT];
            }
            else if (User.RoomsTeacher.ContainsKey(nameT))
            {
                return User.RoomsTeacher[nameT];
            }
            else
            {

                Loadedroom = await LoadRoom(nameT);
                if (Loadedroom.teachers.IndexOf(CU.user_name) > -1)
                //if cu is a techer of that room
                {
                    User.RoomsTeacher.Add(nameT, Loadedroom);
                }
                else
                {
                    User.RoomsStudent.Add(nameT, Loadedroom);
                }
            }
            return Loadedroom;
        }
        public static async Task<Room> LoadRoom(string nameT)
        {
            return await Firestore.Firestore.GetRoomAsync(nameT);


        }


        public static bool UserLogin(/*Argument*/string userid, string password)
        {
            //auth

            var result = Task.Run(async () => await Firestore.Firestore.AuthUser(userid, password)).Result;


            if (Firestore.Firestore.flag)
            {
                program.CU = Firestore.Firestore.tempuser;
                if (User.RoomsTeacher == null) User.RoomsTeacher = new Dictionary<string, Room>();
                if (User.RoomsStudent == null) User.RoomsStudent = new Dictionary<string, Room>();
                if (program.CU.RoomsTeacherRef == null)
                {
                    program.CU.RoomsTeacherRef = new ArrayList();
                    status?.Invoke(CU, "program.CU.RoomsTeacherRef was null");
                }
                if (program.CU.RoomsStudentRef == null) program.CU.RoomsStudentRef = new ArrayList();
                if (classes.User.Allrooms == null) classes.User.Allrooms = new ArrayList();

                classes.User.Allrooms.AddRange(program.CU.RoomsTeacherRef);
                classes.User.Allrooms.AddRange(program.CU.RoomsStudentRef);
                return true;
            }
            else
            {
                return false;
            }

            //set current user 
        }
        public async static Task<Room> CreateRoom(string nameofroom/*Argument*/)
        {


            //create its object
            Room newRoom = new Room
            {
                Name = nameofroom,
                teachers = new ArrayList(),
                students = new ArrayList()

            };

            newRoom.teachers.Add(CU.user_name);
            //add it to view
            //add it to firestore
            await Firestore.Firestore.CreateRoom(newRoom);
            Firestore.Firestore.updateUser(CU.user_name);
            classes.User.RoomsTeacher.Add(newRoom.Name + "#" + newRoom.tag, newRoom);
            CU.RoomsTeacherRef.Add(newRoom.Name + "#" + newRoom.tag);
            classes.User.Allrooms.Add(newRoom.Name + "#" + newRoom.tag);
            //add it to CU array
            return newRoom;
            //cache 
        }

        public static async Task Addstudent(string roomRef, string studentUserId)
        //this should be invitation based 
        {
            var task = Firestore.Firestore.FindUser(studentUserId);

            Firestore.Firestore.FindUser(studentUserId);
            Room room = User.RoomsTeacher[roomRef];
            //check if student already exists in the class
            if (room.IndexOfStudent(studentUserId) > -1)
            {
                status?.Invoke(null, $"{studentUserId} Already exists in {roomRef}");//tryctach

                return;
            }
            //search for the user id

            if (!await task)
            {
                status?.Invoke(null, $"User {studentUserId} Doesn\'t Exist");
                return;//tryctach
            }
            //add it to current room's array
            room.AddStudent(studentUserId);
            room.update();

            //add it to view
            //update current Room
        }
        public async static Task CreatePost(string roomid, string content_)
        {
            var getroomTask = Firestore.Firestore.GetRoomAsync(roomid);
            Post newpost = new Post(content_)
            {
                roomid = roomid
            };
            if (!User.RoomsTeacher.ContainsKey(roomid))
            {

                User.RoomsTeacher.Add(roomid, await getroomTask);
            }

            Room room = User.RoomsTeacher[roomid];
            status?.Invoke(null, $"{room.Name} loaded");

            // newpost.author = CU.user_name;
            room.Postsref.Add(newpost.id);
            await Firestore.Firestore.CreatePost(newpost);
            room.update();



        }

        public async static Task<ArrayList> Getposts(string roomid)
        {
            //int count = 0;
           
            ArrayList postsarray = new ArrayList();
            ArrayList arrayList = new ArrayList();
            CollectionReference postref= Firestore.Firestore.db.Collection("posts");
            Query query = postref.WhereEqualTo("roomid", roomid);
            QuerySnapshot snapshots= await query.GetSnapshotAsync();

           /* DocumentReference docRef = Firestore.Firestore.db.Collection("posts").Document("roomid");
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if(snapshot.Exists)
            {
                postsarray.Add(snapshot.Id);
                Post post = snapshot.ConvertTo<Post>();
                arrayList
            }*/
            
            foreach(DocumentSnapshot documentSnapshot in snapshots.Documents)
            {
                postsarray.Add(documentSnapshot.ConvertTo<Post>());

                //Post post = snapshots.
                //count++;
               /* Dictionary<string, Object> postDictionary = new Dictionary<string, object>();
                foreach(object obj in postsarray)
                {
                    Post posts=documentSnapshot.ConvertTo<Post>();
                    postDictionary.Add(posts.id, posts);
                }*/
                
            }
            return postsarray;
            //return arrayList;
            //... 
           // ...
          //return list_allpost_of_roomid;
        }



    }
}