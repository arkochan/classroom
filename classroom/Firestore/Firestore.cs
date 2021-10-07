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
        public static string rid;
        public static FirestoreDb db;
        public static void Init(string roomcode)
        {
            db = FirestoreDb.Create("classroomt-f83c6");
        }
        //public static classes.Room GetRoom(string roomcode)
        //{
        //    DocumentReference roomdoc = db.Collection("rooms").Document(roomcode);

        //}
        public static string AddRoom(classes.Room room)
        {
            CollectionReference roomscoll = db.Collection("rooms");
            GetRoomId(room.Name);
            Dictionary<string, object> docData = new Dictionary<string, object>()
            {
                { "course_id" , room.course_id },
                { "Name" , room.Name }

            };
            return rid;
        }
        public static async void GetRoomId(string name)
        {
            string rid;
            using (var sha = new System.Security.Cryptography.SHA256Managed())
                while (true)
                {
                    {
                        byte[] textData = System.Text.Encoding.UTF8.GetBytes(name);
                        byte[] hash = sha.ComputeHash(textData);
                        rid = BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                    DocumentReference roomRef = db.Collection("rooms").Document("rid");
                    DocumentSnapshot snapshot = await roomRef.GetSnapshotAsync();
                    if (snapshot.Exists == false)
                        break;
                }

        }
    }
}
