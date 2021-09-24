using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using mathApp.view;
using mathApp.control;
using mathApp.model;
using FontAwesome.Sharp;

namespace mathApp.service
{
    class ProfileService
    {
        private ProfileView view;
        private User user;
        private ControlUsers users;

        public ProfileService(ProfileView view)
        {
            this.view = view;
            users = new ControlUsers(100);
            user = users.get(view.Username);
        }

        public void history_Click(object sender, EventArgs e)
        {
            this.view.Controls.Clear();
            view.AutoScroll = true;
            ControlHistory control = new ControlHistory(100);
            Lista<Operation> history = control.get(view.Username).allOperations();
            Node<Operation> head = history.First;
            int y = 110;
            while(head != null)
            {
                Operation operation = head.Data;
                HistoryCard card = new HistoryCard(operation, view);
                card.setLocation(425, y);
                card.load();
                y += 210;
                head = head.Next;
            }
        }
        public void data_Click(object sender, EventArgs e)
        {
            loadMessage();
            loadDescription();
            loadTextBoxes();
            loadSave();
        }

        private void loadMessage()
        {
            view.Controls.Clear();

            view.Message = new Label();
            view.Message.Parent = view;
            view.Message.Location = new Point(450, 120);
            view.Message.Size = new Size(750, 100);
            view.Message.Font = new Font("Consolas", 13, FontStyle.Bold);
            view.Message.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.Message.Text = "Acestea sunt datele tale\nClick pe orice camp pentru a-l modifica!";
            view.Message.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void loadDescription()
        {
            view.Description = new Label();
            view.Description.Parent = view;
            view.Description.Size = new Size(200, 300);
            view.Description.Location = new Point(550, 250);
            //view.Description.BorderStyle = BorderStyle.FixedSingle;
            view.Description.Font = new Font("Consolas", 15, FontStyle.Bold);
            view.Description.Text = "Username:\n\n\nParola:";
            view.Description.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.Description.TextAlign = ContentAlignment.MiddleCenter;

        }
        private void loadTextBoxes()
        {
            view.UserName = new TextBox();
            view.UserName.Enabled = false;
            view.Password = new TextBox();

            view.UserName.Parent = view.Password.Parent = view;
            view.UserName.Font = view.Password.Font = new Font("Consolas", 20, FontStyle.Bold);
            view.UserName.BorderStyle = view.Password.BorderStyle = BorderStyle.None;
            view.UserName.BackColor = view.Password.BackColor = ColorTranslator.FromHtml("#FFDF6C");
            view.UserName.ForeColor = view.Password.ForeColor = ColorTranslator.FromHtml("#202020");
            view.UserName.Width = view.Password.Width = 200;

            view.UserName.Location = new Point(800, 335);
            view.Password.Location = new Point(800, 435);

            view.UserName.Text = user.Username;
            view.Password.Text = user.Password;

            view.UserName.TextChanged += new EventHandler(this.textBox_TextChanged);
            view.Password.TextChanged += new EventHandler(this.textBox_TextChanged);
        }
        private void loadSave()
        {
            view.Save = new IconButton();
            view.Save.Parent = view;
            view.Save.Size = new Size(150, 150);
            view.Save.Location = new Point(750, 520);
            view.Save.IconChar = IconChar.Save;
            view.Save.IconColor = ColorTranslator.FromHtml("#FFDF6C");
            view.Save.ImageAlign = ContentAlignment.MiddleCenter;
            view.Save.FlatStyle = FlatStyle.Flat;
            view.Save.FlatAppearance.BorderSize = 0;
            view.Save.FlatAppearance.MouseDownBackColor = view.Save.FlatAppearance.MouseOverBackColor = Color.Transparent;
            view.Save.Text = "Save";
            view.Save.Font = new Font("Consolas", 12, FontStyle.Bold);
            view.Save.ForeColor = view.Save.IconColor;
            view.Save.TextAlign = ContentAlignment.BottomCenter;
            view.Save.Visible = false;
            view.Save.Click += new EventHandler(this.save_Click);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Equals(view.Password) && text.Text != user.Password)
                view.Save.Visible = true;
            else if (text.Equals(view.Password) && text.Text == user.Password && view.UserName.Text == user.Username)
                view.Save.Visible = false;
        }
        private void save_Click(object sender, EventArgs e)
        {
            User user = new User(view.UserName.Text, view.Password.Text);
            users.remove(user.Username, this.user);
            users.add(user.Username, user);
            users.write();
            view.Save.Visible = false;
            loadTextBoxes();
        }
    }
}
