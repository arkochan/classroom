using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    public class User
    {

        string department { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string user_name { get; set; }
        public string notification { get; set; }
        public string messeges { get; set; }
        public int role { get; set; }
        
        public string uniqueID;

        public List<string> roomsTeacher = new List<string>();
        public List<string> roomsStudent = new List<string>();
        
        

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
