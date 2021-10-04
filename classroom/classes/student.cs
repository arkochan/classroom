using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    class student: user
    {
        private List<string> enrolledCourses = new List<string>();

        public void addCourses(string courseID) // on review
        {

        }

        public student(string _name, string _password, string _email, string _phone) : base(_name, _password, _email, _phone)
        {
            generateUniqueID();
        }
        ~student() { }

        protected override void generateUniqueID()
        {
            uniqueID = "stu" + email;
        }
        public override bool sendMessages(string msg, string _userName)
        {
            // search teacher username in db
            // send the string to the teacher's msg section
            return true;
        }

        public bool feedback(string _feedback)
        {
            // send feedback to the course section
            return true;
        }
    }
}
