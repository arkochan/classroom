using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    public class Room
    {

        public List<User> teachers = new List<User>();
        public List<User> students = new List<User>();
        public string department_name { get; set; }
        public string Name { get; set; }
        public string course_id { get; set; }
        public string course_outline { get; set; }
        public float credit { get; set; }
        public List<string> feedback = new List<string>();
        int[,] attendece = new int[100, 100]; // on review // attendence[id][day] = 1/0
        Dictionary<string, ExamResult> examresults = new Dictionary<string, ExamResult>(); // student id -> exam result
        CourseResult courseresult = new CourseResult();


        ~Room() { }

        public string learningAnalysis() // send a report of the whole class --> learning curve
        {
            return "test";
        }

    }
}
