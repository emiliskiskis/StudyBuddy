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
            userlist,
            chatSession
        }
        //adds new form of given type
        public static void Add(FormType ftype)                                   
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
                case FormType.chatSession:
                    {
                        Chat form = new Chat();
                        list.Add(form);
                        form.Show();
                        break;
                    }
                default: 
                    break;
            }

        }
        //closes given form
        public static void Remove(Form o)                                    
        {
            list.Remove(o);
            o.Dispose();
        }
        //opens new form of specified type while closing f1
        public static void Open(Form f1, FormType ftype)                      
        {
            Remove(f1);
            Add(ftype);
        }
        
        public static void BackToMain(Form f1)
        {
            Remove(f1);
            Form f = (Form)list[0];
            f.Show();
        }

        public static void AddMain(Form f1)
        {
            list.Add(f1);
        }

        //disposes of all forms
        public static void CloseAllForms()                                      
        {
            for(int x = 0; x < list.Count; )
            {
                Remove((Form)list[x]);
            }
        }


    }
}
