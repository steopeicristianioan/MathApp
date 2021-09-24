using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathApp.model;
using System.IO;
using System.Windows.Forms;

namespace mathApp.control
{
    class ControlOperations : IControl<string , Operation>
    {
        private ChainedHashtable<string, Operation> allOperations;
        private string url = Application.StartupPath + "\\operations.txt";
        private int size;

        public ChainedHashtable<string, Operation> AllOperations { get => this.allOperations; }

        public ControlOperations(int size)
        {
            this.size = size;
            allOperations = new ChainedHashtable<string, Operation>(size);
            read();
        }

        public void read()
        {
            allOperations = new ChainedHashtable<string, Operation>(size);
            StreamReader reader = new StreamReader(url);
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split('|');
                string[] values = words[5].Split(',');
                List<int> opValues = new List<int>();
                if(words[5] != "")
                    foreach (string v in values)
                        opValues.Add(int.Parse(v));
                DateTime time = new DateTime(int.Parse(words[6]), int.Parse(words[7]), int.Parse(words[8]), int.Parse(words[9]), int.Parse(words[10]), int.Parse(words[11]));
                Operation operation = new Operation(int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]), words[0], long.Parse(words[4]), opValues, time);
                allOperations.put(operation.Username, operation);
;           }
            reader.Close();
        }
        public void log() 
        {
            allOperations.print();
        }
        public void write() 
        {
            StreamWriter writer = new StreamWriter(url);
            string result = string.Empty;
            Lista<Operation> values = allOperations.allValues();
            Node<Operation> head = values.First;
            while(head != null)
            {
                result += head.Data.ToString();
                result += "\n";
                head = head.Next;
            }
            writer.Write(result);
            writer.Close();
        }

        public void add(string name, Operation value)
        {
            this.allOperations.put(name, value);
            write();
        }
        public void remove(string name, Operation value)
        {

        }
    }
}
