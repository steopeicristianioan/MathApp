using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mathApp.view
{
    class View : Form
    {
        protected string username;
        public string Username { get => this.username; set => this.username = value; }
        protected Panel container;

        public View(string username, Panel container)
        {
            this.username = username;
            this.container = container;

            this.Dock = DockStyle.Fill;
            this.Size = container.Size;
            this.BackColor = container.BackColor;
        }


    }
}
