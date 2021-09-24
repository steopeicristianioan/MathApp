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
    class PermInput : Input
    {
        public PermInput(SimpleView view) : base(view) 
        {
            loadLetter("P");
            loadTextBoxes();
        }

        public override void loadTextBoxes()
        {
            n = new TextBox();
            n.Text = "1";
            k = new TextBox();
            k.Parent = this;
            k.Font = new Font("Consolas", 14, FontStyle.Bold);
            k.Multiline = true;
            k.MinimumSize = new Size(40, 25);
            k.Width = 40;
            k.Height = 25;
            k.Multiline = false;
            k.BackColor = ColorTranslator.FromHtml("#FFDF6C");
            k.BorderStyle = BorderStyle.None;
            k.ForeColor = ColorTranslator.FromHtml("#202020");
            k.Location = new Point(60, 50);
            k.TextChanged += new EventHandler(textBox_TextChanged);
        }
        protected override void textBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(K, out int kk))
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
