using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    public class Post
    {
        public string id { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public DateTime creationDate { get; set; }
        public string roomid { get; set; }

        public ArrayList comments { get; set; }
        public ArrayList reactors { get; set; }
        public Post(string content_)
        {
            content = content_;
            creationDate = System.DateTime.Now;
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
