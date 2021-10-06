using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    class User
    {

        string department { get; set; }
        protected int age {  get; set;  }  // review
        protected string email { get; set; }
        protected string password { get; set; }
        protected string phone { get; set; }
        protected string user_name { get; set; }
        protected string notification { get; set; }
        protected string messeges { get; set; }
        protected int role { get; set; }
        
        protected string uniqueID;

        public List<Room> asStudent = new List<Room>();
        public List<Room> asTeacher = new List<Room>();

        //protected user(string _name, string _password, string _email, string _phone)
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
        protected void generateUniqueID()
        {

        }
    }
}
