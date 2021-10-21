using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom.classes
{
    public class post
    {
        public int id { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public DateTime creationDate { get; set; }

        public ArrayList comments{ get; set; }


}
}
