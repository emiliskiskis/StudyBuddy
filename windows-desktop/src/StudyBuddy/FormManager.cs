using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    class FormManager
    {
        private static ArrayList list = new ArrayList();

        public static int Add(Form o)
        {
            return list.Add(o);
        }

        public static void Remove(Form o)
        {
            list.Remove(o);
            o.Dispose();
        }
        public static void Close()
        {
            
        }


    }
}
