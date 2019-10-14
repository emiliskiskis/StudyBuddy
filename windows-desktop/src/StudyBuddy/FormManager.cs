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

        public static int Add(Form o)                                   //adds given form
        {
            o.Show();
            return list.Add(o);
        }

        public static void Remove(Form o)                               //disposes of given form
        {
            list.Remove(o);
            o.Dispose();
        }

        public static void Open(Form f1, Form f2)                       //opens form f2 while closing f1
        {
            Remove(f1);
            Add(f2);
        }

        public static void ShowMain()
        {
            Form f = (Form)list[0];
            f.Show();
        }

        public static void Close()                                      //disposes of all forms
        {
            for(int x = list.Count; x > 0; x--)
            {
                Remove((Form)list[x-1]);
            }
        }


    }
}
