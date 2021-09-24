using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathApp.model;
using System.Windows.Forms;
using System.IO;

namespace mathApp.control
{
    class ControlUsers : IControl<string, User>
    {
        ChainedHashtable<string, User> allUsers;
        private int size;
        private string url = Application.StartupPath + "\\users.txt";

        public ControlUsers(int size)
        {
            allUsers = new ChainedHashtable<string, User>(size);
            this.size = size;
            read();
        }

        public void read()
        {
            allUsers = new ChainedHashtable<string, User>(size);
            StreamReader reader = new StreamReader(url);
            string line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split('|');
                User user = new User(words[0], words[1]);
                allUsers.put(user.Username, user);
            }
            reader.Close();
        }
        public void write()
        {
            string result = string.Empty;
            StreamWriter writer = new StreamWriter(url);
            Lista<User> users = allUsers.allValues();
            Node<User> head = users.First;
            while(head != null)
            {
                result += head.Data.ToString();
                result += '\n';
                head = head.Next;
            }
            writer.Write(result);
            writer.Close();
        }
        public void log()
        {
            allUsers.print();
        }

        public void add(string key, User user)
        {
            allUsers.put(key, user);
        }
        public void remove(string key, User user)
        {
            allUsers.remove(key, user);
        }

        public User get(string username)
        {
            return allUsers.get(username);
        }

    }
}
