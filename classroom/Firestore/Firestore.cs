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
        public static bool flag { get; set; }
        public static classes.User tempuser { get; set; }

        public static EventHandler userexisnt;
        public static EventHandler<string> status;

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
        public static async Task<classes.Room> GetRoomAsync(string name)
        {
            DocumentReference roomref = db.Collection("rooms").Document(name);
            DocumentSnapshot roomsnapshot = await roomref.GetSnapshotAsync();
            if (roomsnapshot.Exists) //user exist
            {
                return roomsnapshot.ConvertTo<classes.Room>();
            }
            else
            { return null; }
        }
        public static async Task<bool> AddStudentfs(classes.User user, string rid)
        {
            DocumentReference userref = db.Collection("users").Document(user.user_name);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists) //user exist
            {
                DocumentReference roomref = db.Collection("rooms").Document(rid);
                DocumentSnapshot roomsnapshot = await userref.GetSnapshotAsync();
                classes.Room temp = roomsnapshot.ConvertTo<classes.Room>();
                temp.students.Add(user);
                return true;

            }
            return false;
        }
        public static async Task<bool> CreateRoom(classes.Room room)
        {

            int count = 0;
            string rid, tag;
            DocumentReference roomRef = db.Collection("rooms").Document("rid");
            DocumentSnapshot snapshot;
            while (count++ < 100) //to make risk free 
            {
                tag = GetRandomString();
                rid = room.Name + "#" + tag;
                roomRef = db.Collection("rooms").Document(rid);
                snapshot = await roomRef.GetSnapshotAsync();
                if (snapshot.Exists == false)
                {
                    room.tag = tag;
                    await roomRef.SetAsync(room);
                    return true;
                }
            }
            return false;
        }
        public static async Task<bool> CreateUserfs(classes.User user)
        {
            DocumentReference roomRef;
            DocumentSnapshot snapshot;
            roomRef = db.Collection("users").Document(user.user_name);
            snapshot = await roomRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return false;
            }
            else
            {
                await roomRef.SetAsync(user);
                //program.CU.RoomsTeacher.Add(user) ;
                //update(Program.CU)
                return true;
            }
        }
        public static async Task updateUser(string username)
        {
            DocumentReference roomRef;
            DocumentSnapshot snapshot;
            roomRef = db.Collection("users").Document(username);
            snapshot = await roomRef.GetSnapshotAsync();
            await roomRef.SetAsync(program.CU);
        }
        public static async Task<bool> CreatePost(classes.Post post)
        {

            int count = 0;
            string pid;
            DocumentReference postRef;
            DocumentSnapshot snapshot;
            while (count++ < 100) //to make risk free 
            {

                pid = post.id;
                postRef = db.Collection("posts").Document(pid);
                snapshot = await postRef.GetSnapshotAsync();


                if (snapshot.Exists == false)
                {
                    //room.tag = tag;
                    await postRef.SetAsync(new Dictionary<string, object>
                    {
                        {"id",post.id },
                        {"content",post.content },
                        {"author",post.author },
                        {"creationDate", post.creationDate },
                        {"roomid",post.roomid },
                        {"comments",post.comments },
                        {"reactors",post.reactors }});

                    return true;
                }
                else
                {
                    pid = post.id = GetRandomString(8);
                }
            }
            return false;
        }
        public static async Task<classes.User> GetUserAsync(string id)
        {
            DocumentReference userref = db.Collection("users").Document(id);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<classes.User>();
            }
            else
            {
                return null;
            }
        }
        public static async Task<bool> AuthUser(string id, string pass)
        {   //easy authentication and returns current user if exists
            DocumentReference userref = db.Collection("users").Document(id);
            DocumentSnapshot snapshot = await userref.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                Dictionary<string, object> userdoc = snapshot.ToDictionary();
                if ((string)userdoc["password"] == pass)
                {
                    flag = true;

                    tempuser = snapshot.ConvertTo<classes.User>();
                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        // public static async  Signup(string id, string pass)
        // {   //adds user to db

        // }
        public static async Task<bool> FindUser(string username)
        {


            return (await db.Collection("users").Document(username).GetSnapshotAsync()).Exists;

        }
        public static string GetRandomString(int stringLength = 4)
        {
            StringBuilder sb = new StringBuilder();
            int numGuidsToConcat = (((stringLength - 1) / 32) + 1);
            for (int i = 1; i <= numGuidsToConcat; i++)
            {
                sb.Append(Guid.NewGuid().ToString("N"));
            }

            return sb.ToString(0, stringLength);
        }

    }
}


