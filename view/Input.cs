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
    class Input : Panel
    {
        protected SimpleView parent;
        protected TextBox n;
        public string N { get => this.n.Text; }
        protected TextBox k;
        public string K { get => this.k.Text; }
        protected Label letter;

        public Input(SimpleView container)
        {
            this.parent = container;
            this.Parent = parent;
            this.Size = new Size(125, 125);
            this.Location = new Point(375, 185);
            this.Anchor = AnchorStyles.None;
        }

        public virtual void loadLetter(string l)
        {
            letter = new Label();
            letter.Parent = this;
            letter.Location = new Point(10, 25);
            letter.Size = new Size(50, 75);
            letter.Font = new Font("Consolas", 30, FontStyle.Bold);
            letter.Text = l;
            letter.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            //letter.BorderStyle = BorderStyle.FixedSingle;
            letter.TextAlign = ContentAlignment.TopCenter;
        }
        public virtual void loadTextBoxes()
        {
            n = new TextBox();
            k = new TextBox();

            n.Parent = k.Parent = this;
            n.Font = k.Font = new Font("Consolas", 14, FontStyle.Bold);
            n.Multiline = k.Multiline = true;
            n.MinimumSize = k.MinimumSize = new Size(40, 25);
            n.Width = k.Width = 40;
            n.Height = k.Height = 25;
            n.Multiline = k.Multiline = false;
            n.BackColor = k.BackColor = ColorTranslator.FromHtml("#FFDF6C");
            n.BorderStyle = k.BorderStyle = BorderStyle.None;
            n.ForeColor = k.ForeColor = ColorTranslator.FromHtml("#202020");

            n.Location = new Point(60, 20);
            k.Location = new Point(60, 75);

            n.TextChanged += new EventHandler(this.textBox_TextChanged);
            k.TextChanged += new EventHandler(this.textBox_TextChanged);
        }

        protected virtual void textBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(N, out int nn) && int.TryParse(K, out int kk) && nn <= kk)
            {
                parent.SimpleButton.IconChar = IconChar.CheckCircle;
                parent.SimpleButton.ForeColor = parent.SimpleButton.IconColor = ColorTranslator.FromHtml("#FFDF6C");
                return;
            }
            parent.SimpleButton.IconChar = IconChar.None;
            parent.SimpleButton.ForeColor = parent.SimpleButton.IconColor = ColorTranslator.FromHtml("202020");
        }
    }
}
