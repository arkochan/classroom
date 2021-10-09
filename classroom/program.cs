using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void UserSignup() 
        { 
            
        }
        public static void UserLogin(id) 
        { 
            //set current user
        }
        public static void CreateRoom() 
        { 
            
            //create its object
            //add it to view
            //add it to firestore
            //add it to CU array
            //cache 
        }
        public static void Addstudent() 
        {   //this should be invitation based
            //search for the user id
            //get student object from firestore
            //check if student already exists in the class
            //add it to view
            //add it to current room's array
            //update current Room
        }




    }
}