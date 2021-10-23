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
        public Post()
        {

        }
        public Post(Dictionary<string,object>postDictionary)
        {
            id = null;
            content = postDictionary["content"].ToString();
            id = postDictionary["id"].ToString(); 
            if(postDictionary["author"]!=null)
            author = postDictionary["author"].ToString();
            if (postDictionary["creationDate"]!=null)
                creationDate = postDictionary["creationDate"].ToString();
               
            if (postDictionary["comments"]!=null)
                comments = (ArrayList) postDictionary["comments"];
            if (postDictionary["reactors"]!=null)
                reactors = (ArrayList)postDictionary["reactors"];
        }
        public Post(string content_)
        {
            content = content_;
            creationDate = System.DateTime.Now.ToString();
            id = Firestore.Firestore.GetRandomString(8);
            author = program.CU.user_name;

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
