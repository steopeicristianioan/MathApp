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
    class EcInput : Panel
    {
        #region
        private int letterStatus;
        public int LStatus { get => this.letterStatus; set => this.letterStatus = value; }
        private int ecStatus;
        public int EStatus { get => this.ecStatus; set => this.ecStatus = value; }
        private EcuationView view;
        public EcuationView View { get => this.view; set => this.view = value; }
        #endregion

        public EcInput(int status1, int status2, EcuationView view)
        {
            this.letterStatus = status1;
            this.ecStatus = status2;
            this.view = view;
            timer = new Timer();

            this.Parent = this.view;
            this.Size = new Size(300, 150);
        }
        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        private TextBox nk;
        public TextBox NK { get => this.nk; set => this.nk = value; }
        private Label letter;
        public Label Letter { get => this.letter; set => this.letter = value; }
        private Label sign;
        private TextBox result;
        public TextBox Result { get => this.result; set => this.result = value; }
        private Timer timer;

        public void load()
        {
            setLetter();
            setTextBox();
            loadSign();
            loadResult();
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }
        private void loadResult()
        {
            result = new TextBox();
            result.Parent = this;
            result.Location = new Point(210, 52);
            result.Font = new Font("Consolas", 25, FontStyle.Bold);
            result.Width = 50;
            result.BackColor = ColorTranslator.FromHtml("#FFDF6C");
            result.ForeColor = ColorTranslator.FromHtml("#202020");
            result.BorderStyle = BorderStyle.None;
        }
        private void loadSign()
        {
            sign = new Label();
            sign.Parent = this;
            sign.Font = new Font("Consolas", 30, FontStyle.Bold);
            sign.Size = new Size(75, 55);
            sign.Location = new Point(135, 35);
            sign.Text = "=";
            sign.ForeColor = letter.ForeColor;
            sign.TextAlign = ContentAlignment.TopCenter;
        }
        private void setTextBox()
        {
            nk = new TextBox();
            nk.Parent = this;
            nk.Width = 35;
            if (this.ecStatus == 1)
                nk.Location = new Point(70, 105);
            else nk.Location = new Point(75, 30);
            nk.Font = new Font("Consolas", 14, FontStyle.Bold);
            nk.ForeColor = ColorTranslator.FromHtml("#202020");
            nk.BackColor = ColorTranslator.FromHtml("#FFDF6C");
            nk.BorderStyle = BorderStyle.None;
        }
        private void setLetter()
        {
            letter = new Label();
            letter.Parent = this;
            letter.Size = new Size(50, 70);
            letter.Location = new Point(25, 35);
            letter.Font = new Font("Consolas", 32, FontStyle.Bold);
            letter.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            if (letterStatus == 1)
                letter.Text = "C";
            else letter.Text = "A";
            letter.TextAlign = ContentAlignment.MiddleCenter;
            //letter.BorderStyle = BorderStyle.FixedSingle;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            check();
        }
        private void check()
        {
            if(int.TryParse(NK.Text, out int nk) && int.TryParse(result.Text, out int r) && r > nk)
            {
                if(letterStatus == 1)
                {
                    view.B1.IconChar = IconChar.CheckCircle;
                    view.B1.ForeColor = letter.ForeColor;
                }
                else
                {
                    view.B2.IconChar = IconChar.CheckCircle;
                    view.B2.ForeColor = letter.ForeColor;
                }
            }
            else
            {
                if (letterStatus == 1)
                {
                    view.B1.IconChar = IconChar.None;
                    view.B1.ForeColor = ColorTranslator.FromHtml("#202020");
                }
                else
                {
                    view.B2.IconChar = IconChar.None;
                    view.B2.ForeColor = ColorTranslator.FromHtml("#202020");
                }
            }
        }
    }
}
