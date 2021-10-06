using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom
{
    public class program
    {
        public static string userid;

        program()
        {
            var login_window = new Views.Login();
            login_window.Show();
            
        }
    }
}