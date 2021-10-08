using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace classroom.Firestore
{
    public static class Firestore
    {
        public static EventHandler userexisnt;
        public static string rid { get; set; }
        public static FirestoreDb db;
        public static void Init()
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "classroomt.json");
            db = FirestoreDb.Create("classroomt-f83c6");
        }
        //public static classes.Room GetRoom(string roomcode)
        //{
        //    DocumentReference roomdoc = db.Collection("rooms").Document(roomcode);

        //}
        public static async void AddRoom(classes.Room room)
        {
            CollectionReference roomscoll = db.Collection("rooms");
            GetRoomId();
            ArrayList studentArray = new ArrayList();
            ArrayList teacherArray = new ArrayList();
            
            
            
            foreach (classes.User u in room.students)
            {
                studentArray.Add(u);
            }
            
            Dictionary<string, object> roomData = new Dictionary<string, object>()
            {   
                { "course_id" , room.course_id },
                { "Name" , room.Name },
                { "roomid",room.id }

            };
            await roomscoll.Document(room.Name + room.id).SetAsync(roomData);
        }
        public static async void AddStudentfs(string id)
        {
            DocumentReference userref = db.Collection("users").Document(id);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists)
            {

            }

            else
            {
                
            }
        }
        public static async void GetRoomId()
        {
            var ran = new Random();
            StringBuilder sb = new StringBuilder("    ");
            while (true)
            {
                    for (int i = 0; i < 4; i++)
                    {
                        sb[i] = (char)ran.Next('A', 'Z');
                    }
                    rid = sb.ToString();
                    DocumentReference roomRef = db.Collection("rooms").Document("rid");
                    DocumentSnapshot snapshot = await roomRef.GetSnapshotAsync();
                    if (snapshot.Exists == false)
                        break;
            }

        }

    }
}


