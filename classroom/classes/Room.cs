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
    public class Room
    {
        [FirestoreProperty]
        public ArrayList teachers { get; set; }
        [FirestoreProperty]
        public ArrayList students { get; set; } 
        [FirestoreProperty]
        public ArrayList Postsref { get; set; }
        [FirestoreProperty]
        public string department_name { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string tag { get; set; }
        [FirestoreProperty]
        public string course_id { get; set; }
        [FirestoreProperty]
        public string course_outline { get; set; }
        [FirestoreProperty]
        public float credit { get; set; }

        //public List<string> feedback = new List<string>();

       // int[,] attendece = new int[100, 100]; // on review // attendence[id][day] = 1/0
       // Dictionary<string, ExamResult> examresults = new Dictionary<string, ExamResult>(); // student id -> exam result
       // CourseResult courseresult = new CourseResult();
       public Room()
        {
            Postsref = new ArrayList();
        }

        ~Room() { }
        public void AddStudent(string userid)
        {
            students.Add(userid);
        }
        public string learningAnalysis() // send a report of the whole class --> learning curve
        {
            return "test";
        }
        public int IndexOfStudent(string id)
        {
            return students.IndexOf(id);
        }
        public void update()
        {
            DocumentReference docRef = Firestore.Firestore.db.Collection("rooms").Document(Name+"#"+tag);
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                { "students" , students },
                { "teachers" , teachers }
            };
            docRef.UpdateAsync(update);
        }
    }
}
