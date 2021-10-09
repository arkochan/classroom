using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classroom.classes;
using classroom.Firestore;

namespace classroom
{

    public static class program
    {
        public static classes.currentUser CU;
        public static string userid;

        public static void Init()
        {
            Views.Login login_window = new Views.Login();
            login_window.Show();
            UserLogin(login_window.namebox.Text, login_window.pwbox.Password);


        }

        public static void UserSignup(string _username, string _password/*Argument*/)
        {

            //create new user object
            User newUser = new User
            {
                user_name = _username,
                password = _password

            };

            //put it in fs
            Firestore.Firestore.CreateUserfs(newUser);



        }

        public static void UserLogin(/*Argument*/string userid, string password)
        {
            //auth
            //set current user 
        }
        public static void CreateRoom(string roomname_)
        {

            //create its object
            Room newRoom = new Room
            {
                Name = roomname_;
            }
           
            //add it to view
            //add it to firestore
            //add it to CU array
            CU.roomTeacher.Add(newRoom);
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