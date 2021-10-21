using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
namespace classroom.classes
{
    public class Post
    {
        [FirestoreProperty]
        public string id { get; set; }
        [FirestoreProperty]
        public string content { get; set; }
        [FirestoreProperty]
        public string author { get; set; }
        [FirestoreProperty]

        public string creationDate { get; set; }
        [FirestoreProperty]
        public string roomid { get; set; }
        [FirestoreProperty]
        public ArrayList comments { get; set; }
        [FirestoreProperty]
        public ArrayList reactors { get; set; }
        public Post(string content_)
        {
            content = content_;
            creationDate = System.DateTime.Now.ToString();
            id = Firestore.Firestore.GetRandomString(8);
            

        }
        public int ReactCount()
        {
            return reactors.Count;
        }
        public void AddReaction(string userid)
        {
            reactors.Add(userid);
        }
        public bool DidReact(string userid)
        {
            return reactors.IndexOf(userid) > -1;
        }
        public bool DidReact()
        {
            return reactors.IndexOf(program.CU.user_name) > -1;
        }

    }
}
