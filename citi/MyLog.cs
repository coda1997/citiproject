using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citi
{
    class MyLog
    {
        public static void FailLog(String mess) {
            Console.WriteLine(mess);
        }
        public static void FailLog(String Tag,String mess)
        {
            FailLog(Tag + " : " + mess);
        }

    }
}
