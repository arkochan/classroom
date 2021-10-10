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
        public static classes.User CU;

        public static void Init()
        {

            CU = new User();
            program.CU.RoomsTeacher = new ArrayList();
            program.CU.RoomsStudent = new ArrayList();
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

        public static void UserLogin(/*Argument*/string userid, string password)
        {
            //auth
            
            Firestore.Firestore.AuthUser(userid, password);
            if (Firestore.Firestore.flag)
            {
                program.CU = Firestore.Firestore.tempuser;

            } 


            //set current user 
        }
        public static void CreateRoom(string nameofroom/*Argument*/)
        {

            //create its object
            Room newRoom = new Room
            {
                Name = nameofroom
            };
            //add it to view
            //add it to firestore
            Firestore.Firestore.CreateRoom(newRoom);
            //add it to CU array
            program.CU.RoomsTeacher.Add(newRoom);
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