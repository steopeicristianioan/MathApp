using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using mathApp.model;

namespace mathApp.control
{
    class ControlHistory : IControl<string , History>
    {
        private ChainedHashtable<string, History> allHistory;
        private int size;
        private string url = Application.StartupPath + "\\history.txt";
        private ControlOperations operations;

        public ControlHistory(int size)
        {
            this.size = size;
            this.allHistory = new ChainedHashtable<string, History>(size);
            this.operations = new ControlOperations(size);
            read();
        }

        public void read()
        {
            this.allHistory = new ChainedHashtable<string, History>(size);
            StreamReader reader = new StreamReader(url);
            string line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                History history = new History(line, this.operations.AllOperations);
                this.allHistory.put(history.Username, history);
            }
            reader.Close();
        }
        public void log()
        {
            allHistory.print();
        }
        public void write()
        {
            StreamWriter writer = new StreamWriter(url);
            string result = string.Empty;
            Lista<History> values = this.allHistory.allValues();
            Node<History> head = values.First;
            while(head != null)
            {
                result += head.Data.ToString();
                result += '\n';
                head = head.Next;
            }
            writer.Write(result);
            writer.Close();
        }


        public void add(string name, History value)
        {

        }
        public void remove(string name, History value)
        {

        }
        public void getHistory(string key)
        {
            History history = allHistory.get(key);
            if(history != null)
                history.log();
            else Console.WriteLine("User doesn't exist");
        }
        public History get(string key)
        {
            History history = allHistory.get(key);
            return history;
        }
    }
}
