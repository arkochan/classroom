using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    abstract class user
    {

        protected string department { get; set; }
        protected int age {  get; set;  }  // review
        protected string email { get; set; }
        protected string password { get; set; }
        protected string phone { get; set; }
        protected string name { get; set; }
        protected string notification { get; set; }
        protected string messeges { get; set; }
        protected int role { get; set; }
        
        protected string uniqueID;

        protected user(string _name, string _password, string _email, string _phone)
        {
            name = _name;
            password = _password;
            email = _email;
            phone = _phone;
        }

        ~user() { }

        public abstract bool sendMessages(string msg, string _userName);
        protected abstract void generateUniqueID();
    }
}
