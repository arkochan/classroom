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
    public static void CreateRoom(/*Argument*/)
    {

        //create its object
        //add it to view
        //add it to firestore
        //add it to CU array
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