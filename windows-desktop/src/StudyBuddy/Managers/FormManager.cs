using System.Collections.Generic;
using System.Windows.Forms;
using StudyBuddy.Forms;
using MainMenu = StudyBuddy.Forms.MainMenu;

namespace StudyBuddy.Managers
{
    public class FormManager : ApplicationContext
    {
        private readonly NetworkManager _networkManager;
        private readonly Validator _validator;
        private readonly List<Form> list = new List<Form>();

        public FormManager(NetworkManager networkManager)
        {
            _networkManager = networkManager;
            _validator = new Validator(_networkManager);
            Add(FormType.main);
        }

        public enum FormType
        {
            main,
            signin,
            register,
            userlist,
            chatSession
        }

        //adds new form of given type
        public void Add(FormType ftype)
        {
            switch (ftype)
            {
                case FormType.main:
                    {
                        MainMenu form = new MainMenu(this, _networkManager);
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.register:
                    {
                        Register form = new Register(this, _networkManager);
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.signin:
                    {
                        SignIn form = new SignIn(this, _networkManager, _validator);
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.userlist:
                    {
                        UserList form = new UserList(this, _networkManager);
                        list.Add(form);
                        form.Show();
                        break;
                    }
                case FormType.chatSession:
                    {
                        //Chat form = new Chat(_networkManager);
                        //list.Add(form);
                        //form.Show();
                        break;
                    }
                default:
                    break;
            }
        }

        public void AddMain(Form f1)
        {
            list.Add(f1);
        }

        public void BackToMain(Form f1)
        {
            Remove(f1);
            Form f = list[0];
            f.Show();
        }

        //disposes of all forms
        public void CloseAllForms()
        {
            for (int x = 0; x < list.Count;)
            {
                Remove(list[x]);
            }
        }

        //opens new form of specified type while closing f1
        public void Open(Form f1, FormType ftype)
        {
            Remove(f1);
            Add(ftype);
        }

        public void OpenChat(Form f1, string groupName)
        {
            Remove(f1);
            Chat form = new Chat(this, _networkManager, groupName);
            list.Add(form);
            form.Show();
        }

        //closes given form
        public void Remove(Form o)
        {
            list.Remove(o);
            o.Dispose();
        }
    }
}
