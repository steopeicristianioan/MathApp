using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mathApp.model;
using System.Drawing;

namespace mathApp.view
{
    class HistoryCardIcon : Panel
    {
        private Operation operation;
        private HistoryCard parent;

        private Label letter;
        private Label n;
        private Label k;

        public HistoryCardIcon(Operation op, HistoryCard parent)
        {
            this.operation = op;
            this.parent = parent;
            this.Parent = parent;
            this.Size = new Size(150, 150);
        }
        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }
        public void loadIcon()
        {
            loadLetter();
            loadNK();
        }
        private void loadLetter()
        {
            letter = new Label();
            letter.Parent = this;
            letter.Size = new Size(70, 70);
            letter.Location = new Point(10, 35);
            //letter.BorderStyle = BorderStyle.FixedSingle;
            letter.Font = new Font("Consolas", 30, FontStyle.Bold);
            letter.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            letter.TextAlign = ContentAlignment.MiddleCenter;

            if (operation.Type == 1)
                letter.Text = "C";
            else if (operation.Type == 2)
                letter.Text = "A";
            else if (operation.Type == 3)
                letter.Text = "P";
        }
        private void loadNK()
        {
            n = new Label();
            k = new Label();
            n.Parent = k.Parent = this;
            n.Location = new Point(60, 100);
            k.Location = new Point(60, 7);

            n.ForeColor = k.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            n.Font = k.Font = new Font("Consolas", 15, FontStyle.Bold);
            n.Size = k.Size = new Size(50, 30);
            n.TextAlign = k.TextAlign = ContentAlignment.MiddleCenter;

            n.Text = operation.N.ToString();
            k.Text = operation.K.ToString();
        }
    }
}
