using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    class course
    {
        public string department_name { get; set; }
        public string course_id { get; set; }
        public string course_outline { get; set; }
        public string syllabus { get; set; }
        public float credit { get; set; }
        // buffer ??

        // for attendence we can maintain a google attendence sheet or, a 2D int array

        int[,] attendece = new int[100, 100]; // on review

        List<examResult> examresult = new List<examResult>();

        courseResult courseresult = new courseResult();

        public course(string _deptName, string courseid) 
        {
            department_name = _deptName;
            course_id = courseid;
        }

        ~course() { }

        public string learningAnalysis() // send a report of the whole class --> learning curve
        {
            return "test";
        }

    }
}
