using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
    //created once for current user to keep usefull information 
    //after each query 
{
    public class currentUser : User
    {
        List<Room> roomTeacher = new List<Room>();
        List<Room> roomStudent = new List<Room>();


    }
}
