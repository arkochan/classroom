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

            if(!await task)
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
        




    }
}