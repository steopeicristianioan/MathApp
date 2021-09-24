using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using mathApp.service;

namespace mathApp.view
{
    class ProfileView : View
    {
        private IconButton data;
        public IconButton Data { get => this.data; set => this.data = value; }
        private IconButton history;
        public IconButton History { get => this.history; set => this.history = value; }
        private Font font = new Font("Consolas", 14, FontStyle.Bold);
        private ProfileService service;

        public ProfileView(string username, Panel parent) : base(username, parent)
        {
            service = new ProfileService(this);
            setComon();
            setData();
            setHistory();
        }

        private TextBox name;
        public TextBox UserName { get => this.name; set => this.name = value; }
        private TextBox password;
        public TextBox Password { get => this.password; set => this.password = value; }
        private Label description;
        public Label Description { get => this.description; set => this.description = value; }
        private Label message;
        public Label Message { get => this.message; set => this.message = value; }
        private IconButton save;
        public IconButton Save { get => this.save; set => this.save = value; }

        private void setComon()
        {
            data = new IconButton();
            history = new IconButton();

            data.Parent = history.Parent = this;
            data.FlatStyle = history.FlatStyle = FlatStyle.Flat;
            data.FlatAppearance.BorderSize = history.FlatAppearance.BorderSize = 0;
            data.FlatAppearance.MouseOverBackColor = history.FlatAppearance.MouseOverBackColor = Color.Transparent;
            data.FlatAppearance.MouseDownBackColor = history.FlatAppearance.MouseDownBackColor = Color.Transparent;
            data.ForeColor = history.ForeColor = ColorTranslator.FromHtml("#202020");
            data.Size = history.Size = new Size(500, 100);
            data.TextImageRelation = history.TextImageRelation = TextImageRelation.ImageBeforeText;
            data.IconColor = history.IconColor = ColorTranslator.FromHtml("#FFDF6C");
            data.Font = history.Font = font;
            data.ImageAlign = history.ImageAlign = data.TextAlign = history.TextAlign = ContentAlignment.MiddleCenter;
            data.Anchor = history.Anchor = AnchorStyles.None;

            data.MouseHover += new EventHandler(this.Button_Hover);
            history.MouseHover += new EventHandler(this.Button_Hover);

            data.MouseLeave += new EventHandler(this.Button_Leave);
            history.MouseLeave += new EventHandler(this.Button_Leave);
        }
        private void setData()
        {
            data.Location = new Point(650, 250);
            data.IconChar = IconChar.Server;
            data.Text = "Datele mele";

            data.Click += new EventHandler(this.service.data_Click);
        }
        private void setHistory()
        {
            history.Location = new Point(600, 400);
            history.IconChar = IconChar.History;
            history.Text = "Calculele mele - istoric";
            history.Click += new EventHandler(service.history_Click);
        }

        private void Button_Hover(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            button.IconColor = ColorTranslator.FromHtml("#202020");
            button.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
        }
        private void Button_Leave(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            button.IconColor = ColorTranslator.FromHtml("#FFDF6C");
            button.ForeColor = ColorTranslator.FromHtml("#202020");
        }
    }
}
