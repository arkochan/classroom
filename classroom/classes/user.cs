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
        [FirestoreProperty]

        public string email { get; set; }
        [FirestoreProperty]
        public string password { get; set; }
        //[FirestoreProperty]
        //public string phone { get; set; }
        [FirestoreProperty]
        public string user_name { get; set; }
        [FirestoreProperty]
        public string tag { get; set; }

        //[FirestoreProperty]
        //  public string notification { get; set; }

        // [FirestoreProperty]
        //  public string messeges { get; set; }

        // [FirestoreProperty]
        //   public int role { get; set; }



        [FirestoreProperty]
        public ArrayList RoomsTeacher { get; set; }

        [FirestoreProperty]
        public ArrayList RoomsStudent { get; set; }



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
        public void generateUniqueID()
        {

        }
    }
}
