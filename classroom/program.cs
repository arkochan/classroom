using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom
{
    public static class program
    {
        public static string userid;

        public static void Init()
        {
            Views.Login login_window = new Views.Login();
            login_window.Show();


        }
        
    }
}