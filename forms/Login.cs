using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using mathApp.control;
using mathApp.model;

namespace mathApp.forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private TextBox name;
        public string NAME { get => this.name.Text; }
        private TextBox password;
        private IconButton button;
        private Label message;

        private void Login_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.MaximumSize = new Size(500, 500);
            this.CenterToScreen();
            this.SetDesktopLocation(700, 250);
            this.BackColor = ColorTranslator.FromHtml("#202020");
            loadTextBoxes();
            setButton();
            loadMessage();
        }

        private void loadMessage()
        {
            message = new Label();
            message.Parent = this;
            message.Size = new Size(400, 100);
            message.Location = new Point(50, 10);
            message.Font = new Font("Consolas", 15, FontStyle.Bold);
            message.TextAlign = ContentAlignment.MiddleCenter;
            message.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            message.Text = "Login si incepe sa rezolvi probleme!";
        }
        private void loadTextBoxes()
        {
            name = new TextBox();
            password = new TextBox();

            name.Parent = password.Parent = this;
            name.Location = new Point(100, 150);
            password.Location = new Point(100, 200);
            name.ForeColor = password.ForeColor = ColorTranslator.FromHtml("202020");
            name.BackColor = password.BackColor = ColorTranslator.FromHtml("#FFDF6C");
            name.Font = password.Font = new Font("Conosolas", 15, FontStyle.Bold);
            name.Width = password.Width = 300;
            name.Text = "Username";
            password.Text = "Parola";
            
            name.Click += new EventHandler(this.textBox_Click);
            password.Click += new EventHandler(this.textBox_Click);
        }
        private void setButton()
        {
            button = new IconButton();
            button.Parent = this;
            button.Size = new Size(200, 100);
            button.Location = new Point(140, 300);
            button.IconChar = IconChar.ClipboardCheck;
            button.IconColor = name.BackColor;
            button.FlatStyle = FlatStyle.Flat;
            
            button.Click += new EventHandler(button_Click);
        }
        private void button_Click(object sender, EventArgs e)
        {
            ControlUsers users = new ControlUsers(100);
            User user = users.get(this.name.Text);
            if (user == default(User))
                MessageBox.Show("Please check your username again!");
            else if (user.Password != this.password.Text)
                MessageBox.Show("Invalid password");
            else
            {
                MainForm main = new MainForm(user.Username);
                main.Show();
                this.Hide();
            }
        }
        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Equals(name) && text.Text == "Username")
                name.Text = string.Empty;
            else if (text.Equals(password) && text.Text == "Parola")
            {
                password.Text = string.Empty;
                password.PasswordChar = '*';
            }

        }
    }
}
