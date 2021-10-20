using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classroom.classes;
using classroom.Firestore;

namespace classroom
{

    public static class program
    {
        public static User CU;
       
        static program()
        {
            Firestore.Firestore.Init();
            CU = new User
            {
                RoomsStudent = new ArrayList(),
                RoomsTeacher = new ArrayList()
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


        public static bool UserLogin(/*Argument*/string userid, string password)
        {
            //auth

            var result = Task.Run(async () => await Firestore.Firestore.AuthUser(userid, password)).Result;


            if (Firestore.Firestore.flag)
            {
                program.CU = Firestore.Firestore.tempuser;
                if (program.CU.RoomsTeacher == null) program.CU.RoomsTeacher = new ArrayList();
                if (program.CU.RoomsStudent == null) program.CU.RoomsStudent = new ArrayList();
                if (program.CU.RoomsTeacherRef == null) program.CU.RoomsTeacherRef = new ArrayList();
                if (program.CU.RoomsStudentRef == null) program.CU.RoomsStudentRef = new ArrayList();
                if (classes.User.Allrooms == null) classes.User.Allrooms = new ArrayList();
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
            CU.RoomsTeacher.Add(newRoom);
            CU.RoomsTeacherRef.Add(newRoom.Name + "#" + newRoom.tag);
            classes.User.Allrooms.Add(newRoom.Name);
            //add it to CU array
            return newRoom;
            //cache 
        }
        public static void Addstudent(/*Argument*/)
        {
            //this should be invitation based 



            //search for the user id
            //get student object from firestore
            //check if student already exists in the class
            //add it to view
            //add it to current room's array
            //update current Room
        }
        


    }
}