using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;

namespace mathApp.view
{
    class PickNumbers : Panel
    {
        private SimpleView view;
        private Font font = new Font("Consolas", 15, FontStyle.Bold);

        private TextBox text;
        public TextBox Textbox { get => this.text; }
        private Label message;

        private int[] f;

        private Timer timer;

        public PickNumbers(SimpleView container)
        {
            this.view = container;
            this.Parent = container;

            this.Size = new Size(500, 125);
            this.Anchor = AnchorStyles.None;
            //this.BorderStyle = BorderStyle.FixedSingle;

            timer = new Timer();
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }

        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        private void loadMessage()
        {
            message = new Label();
            message.Parent = this;
            message.Location = new Point(20, 25);
            message.Size = new Size(500, 50);
            message.Font = new Font("Consolas", 10, FontStyle.Bold);
            message.Text = "Alege-ti numerele (separate prin virgula)";
            message.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            //message.BorderStyle = BorderStyle.FixedSingle;
        }
        private void loadText()
        {
            text = new TextBox();
            text.Parent = this;
            text.Location = new Point(10, 75);
            text.Font = font;
            text.Width = 480;
            text.BackColor = message.ForeColor;
            text.Text = "Insereaza numerele aici";
            text.ForeColor = ColorTranslator.FromHtml("#202020");

            text.Click += new EventHandler(this.text_Click);
            text.TextChanged += new EventHandler(this.textbox_TextChanged);
        }
        private void text_Click(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if(text.Text == "Insereaza numerele aici")
                text.Text = string.Empty;
        }
        public void load()
        {
            loadMessage();
            loadText();
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            f = new int[10000];
            string[] words = text.Text.Split(',');
            if (words.Length == 0 || view.SimpleButton.IconChar == IconChar.None)
            {
                view.PickButton.ForeColor = ColorTranslator.FromHtml("#202020");
                return;
            }
            if(int.Parse(view.Input.K) > words.Length)
            {
                view.PickButton.ForeColor = ColorTranslator.FromHtml("#202020");
                return;
            }
            foreach(string word in words)
            {
                if (!int.TryParse(word, out int w) || f[w] > 0)
                {
                    view.PickButton.ForeColor = ColorTranslator.FromHtml("#202020");
                    return;
                }
                else f[w]++;
            }
            view.PickButton.IconChar = IconChar.CheckCircle;
            view.PickButton.IconColor = view.PickButton.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!int.TryParse(view.Input.N, out int nn) || view.SimpleButton.IconChar == IconChar.None)
            {
                view.PickButton.IconChar = IconChar.None;
                view.PickButton.ForeColor = ColorTranslator.FromHtml("#202020");
                return;
            }
            if (!int.TryParse(view.Input.K, out int kk) || kk != text.Text.Split(',').Length)
            {
                view.PickButton.IconChar = IconChar.None;
                view.PickButton.ForeColor = ColorTranslator.FromHtml("#202020");
                return;
            }
            foreach (string word in text.Text.Split(','))
                if (!int.TryParse(word, out int ww))
                {
                    view.PickButton.IconChar = IconChar.None;
                    view.PickButton.ForeColor = ColorTranslator.FromHtml("#202020");
                    return;
                }
            view.PickButton.IconChar = IconChar.CheckCircle;
            view.PickButton.ForeColor = view.PickButton.IconColor = ColorTranslator.FromHtml("#FFDF6C");
        }
    }
}
