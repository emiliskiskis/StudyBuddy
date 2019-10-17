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
        private static readonly List<Form> list = new List<Form>();
        public enum FormType
        {
            main,
            signin,
            register,
            userlist
        }
        
        public static void Add(FormType ftype)                                   //adds new form of given type
        {
            switch (ftype)
            {
                case FormType.main:
                    {
                        MainMenu form = new MainMenu();
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.register:
                    {
                        Register form = new Register();
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.signin:
                    {
                        SignIn form = new SignIn();
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.userlist:
                    {
                        UserList form = new UserList();
                        list.Add(form);
                        form.Show();
                        break;
                    }
                default: break;
            }

        }

        private static void Remove(Form o)                                    //closes given form
        {
            list.Remove(o);
            o.Close();
        }

        public static void Open(Form f1, FormType ftype)                       //opens new form of specified type while closing f1
        {
            Remove(f1);
            Add(ftype);
        }
        
        private static void ShowMain()
        {
            Form f = (Form)list[0];
            f.Show();
        }

        public static void AddMain(Form f1)
        {
            list.Add(f1);
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
