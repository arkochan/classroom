using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace classroom.Firestore
{
    public static class Firestore
    {
        public static string rid { get; set; }
        public static FirestoreDb db;
        public static void Init(string roomcode)
        {
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
            Dictionary<string, object> roomData = new Dictionary<string, object>()
            {
                { "course_id" , room.course_id },
                { "Name" , room.Name },
                { "roomid",room.id }

            };
            await roomscoll.Document(room.Name + room.id).SetAsync(roomData);
        }
        public static async void GetRoomId()
        {
            var ran = new Random();
            StringBuilder sb = new StringBuilder("    ");
            while (true)
            {
                try
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
                catch
                {

                }
            }

        }

    }
}


