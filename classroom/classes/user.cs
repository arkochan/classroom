using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace classroom.classes
{
    [FirestoreData]
    public partial class User
    {
        
        public static ArrayList Allrooms { get; set; }
        public User()
        {
            RoomsTeacher = new Dictionary<string, Room>();
            RoomsStudent = new Dictionary<string, Room>();
        }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string password { get; set; }
        [FirestoreProperty]
        public string user_name { get; set; }  
        public static Dictionary<string, Room> RoomsTeacher { get; set; }
        public static Dictionary<string, Room> RoomsStudent { get; set; }





        [FirestoreProperty]
        public ArrayList RoomsTeacherRef { get; set; }
        [FirestoreProperty]
        public ArrayList RoomsStudentRef { get; set; }

        //public user(string _name, string _password, string _email, string _phone)
        //{
        //    user_name = _name;
        //    password = _password;
        //    email = _email;
        //    phone = _phone;
        //}

        ~User() { }

        public bool sendMessages(string msg)
        {
            return true;
        }
        public void addRoom(classes.Room room)
        {

        }
        public bool IsTeacher(string roomName)
        {
           return RoomsTeacherRef.IndexOf(roomName)>-1;
        }
        public void generateUniqueID()
        {

        }
    }
}
