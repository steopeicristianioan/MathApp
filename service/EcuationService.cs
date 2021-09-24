using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using mathApp.view;
using FontAwesome.Sharp;

namespace mathApp.service
{
    class EcuationService
    {
        private EcuationView view;
        public EcuationService(EcuationView view)
        {
            this.view = view;
        }

        public void k_Click(object sender, EventArgs e)
        {
            loadMessage();
            loadInputs(1);
            loadButtons();
            setResults();
        }
        public void n_Click(object sender, EventArgs e)
        {
            loadMessage();
            loadInputs(2);
            loadButtons();
            setResults();
        }

        private void loadInputs(int k)
        {
            if (k == 1)
            {
                view.EC1 = new EcInput(1, 1, view);
                view.EC1.setLocation(410, 250);
                view.EC1.load();
                view.EC2 = new EcInput(2, 1, view);
                view.EC2.setLocation(410, 420);
                view.EC2.load();
            }
            else
            {
                view.EC1 = new EcInput(1, 2, view);
                view.EC1.setLocation(410, 250);
                view.EC1.load();
                view.EC2 = new EcInput(2, 2, view);
                view.EC2.setLocation(410, 420);
                view.EC2.load();
            }
        }
        private void loadButtons()
        {
            view.B1 = new IconButton();
            view.B2 = new IconButton();

            view.B1.Parent = view.B2.Parent = view;
            view.B1.Size = view.B2.Size = new Size(220, 100);
            view.B1.ForeColor = view.B2.ForeColor = ColorTranslator.FromHtml("#202020");
            view.B1.Font = view.B2.Font = new Font("Consolas", 15, FontStyle.Bold);
            if (view.EC1.EStatus == 1)
                view.B1.Text = view.B2.Text = "Afla k";
            else view.B1.Text = view.B2.Text = "Afla n";
            view.B1.TextImageRelation = view.B2.TextImageRelation = TextImageRelation.ImageBeforeText;
            view.B1.ImageAlign = view.B1.TextAlign = view.B2.ImageAlign = view.B2.TextAlign = ContentAlignment.MiddleLeft;
            view.B1.FlatStyle = view.B2.FlatStyle = FlatStyle.Flat;
            view.B1.FlatAppearance.BorderSize = view.B2.FlatAppearance.BorderSize = 0;
            view.B1.FlatAppearance.MouseDownBackColor = view.B1.FlatAppearance.MouseOverBackColor = view.B2.FlatAppearance.MouseDownBackColor = view.B2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            view.B1.IconColor = view.B2.IconColor = ColorTranslator.FromHtml("#FFDF6C");

            view.B1.Location = new Point(730, 275);
            view.B2.Location = new Point(730, 450);

            view.B1.Click += delegate (object sender2, EventArgs e2) { this.solve_Click(sender2, e2, 1); };
            view.B2.Click += delegate (object sender2, EventArgs e2) { this.solve_Click(sender2, e2, 2); };
        }
        private void setResults()
        {
            view.R1 = new Label();
            view.R2 = new Label();

            view.R1.Parent = view.R2.Parent = view;
            view.R1.Size = view.R2.Size = new Size(250, 100);
            //view.R1.BorderStyle = view.R2.BorderStyle = BorderStyle.FixedSingle;
            view.R1.Font = view.R2.Font = new Font("Consolas", 14, FontStyle.Bold);
            view.R1.ForeColor = view.R2.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.R1.TextAlign = view.R2.TextAlign = ContentAlignment.MiddleCenter;

            view.R1.Location = new Point(975, 275);
            view.R2.Location = new Point(975, 450);
        }
        private void loadResult(int letterStatus)
        {
            long res = 0;
            if (view.EC1.EStatus == 1 && view.EC2.EStatus == 1)
            {
                if(letterStatus == 1)
                {
                    view.R1.Visible = true;
                    res = Solve.getKFromComb(int.Parse(view.EC1.NK.Text), int.Parse(view.EC1.Result.Text));
                }
                else
                {
                    view.R2.Visible = true;
                    res = Solve.getKFromAranj(int.Parse(view.EC2.NK.Text), int.Parse(view.EC2.Result.Text));
                }
            }
            else
            {
                if (letterStatus == 1)
                {
                    view.R1.Visible = true;
                    res = Solve.getNFromComb(int.Parse(view.EC1.NK.Text), int.Parse(view.EC1.Result.Text));
                }
                else
                {
                    view.R2.Visible = true;
                    res = Solve.getNFromAranj(int.Parse(view.EC2.NK.Text), int.Parse(view.EC2.Result.Text));
                }     
            }

            if (letterStatus == 1)
            {
                if (res == -1)
                    view.R1.Text = "Ecuatia nu are solutie";
                else view.R1.Text = "Solutia este\n" + res.ToString();
            }
            else
            {
                if (res == -1)
                    view.R2.Text = "Ecuatia nu are solutie";
                else view.R2.Text = "Solutia este\n" + res.ToString();
            }
        }
        private void solve_Click(object sender, EventArgs e, int letterStatus)
        {
            IconButton button = (IconButton)sender;
            if (button.IconChar == IconChar.None)
                return;
            loadResult(letterStatus);
        }
        private void loadMessage()
        {
            view.Controls.Clear();

            view.Message = new Label();
            view.Message.Parent = view;
            view.Message.Location = new Point(450, 120);
            view.Message.Size = new Size(750, 100);
            view.Message.Font = new Font("Consolas", 15, FontStyle.Bold);
            view.Message.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.Message.Text = "Completeaza si afla solutiile!";
            view.Message.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
