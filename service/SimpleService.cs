using mathApp.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using mathApp.model;
using mathApp.control;

namespace mathApp.service
{
    class SimpleService
    {
        private SimpleView view;

        public SimpleService(SimpleView view)
        {
            this.view = view;
        }

        public void combinari_Click(object sender, EventArgs e)
        {
            view.Controls.Clear();
            loadPickNumbers();
            loadFormula(1);
            loadInput(1);
            loadSimpleLabel();
            loadSimpleButton(1);
            loadPickLabel();
            loadPickButton(1);
        }
        public void aranjamente_Click(object sender, EventArgs e)
        {
            view.Controls.Clear();
            loadPickNumbers();
            loadFormula(2);
            loadInput(2);
            loadSimpleLabel();
            loadSimpleButton(2);
            loadPickLabel();
            loadPickButton(2);
        }
        public void permutari_Click(object sender, EventArgs e)
        {
            view.Controls.Clear();
            loadPickNumbers();
            loadFormula(3);
            loadInput(3);
            loadSimpleLabel();
            loadSimpleButton(3);
            loadPickLabel();
            loadPickButton(3);
        }
        private void loadPickNumbers()
        {
            view.Pick = new PickNumbers(this.view);
            view.Pick.setLocation(375, 400);
            view.Pick.load();
        }
        private void loadFormula(int k)
        {
            view.Formula = new PictureBox();
            view.Formula.Parent = view;
            view.Formula.Location = new Point(850, 20);
            view.Formula.Size = new Size(600, 300);
            view.Formula.SizeMode = PictureBoxSizeMode.StretchImage;
            if(k==1)
                view.Formula.Image = Image.FromFile(Application.StartupPath + "\\resources\\combinari.png");
            else if (k == 2)
                view.Formula.Image = Image.FromFile(Application.StartupPath + "\\resources\\aranjamente.png");
            else view.Formula.Image = Image.FromFile(Application.StartupPath + "\\resources\\permutari.png");
            view.Formula.Anchor = AnchorStyles.None;
            //view.Formula.BorderStyle = BorderStyle.FixedSingle;
        }
        private void loadInput(int k)
        {
            if (k == 3)
            {
                view.Input = new PermInput(view);
                return;
            }
            view.Input = new Input(view);
            if (k == 1)
                view.Input.loadLetter("C");
            if (k == 2)
                view.Input.loadLetter("A");
            view.Input.loadTextBoxes();
        }
        private void loadSimpleLabel()
        {
            view.Simple = new Label();
            view.Simple.Parent = view;
            view.Simple.Location = new Point(375, 125);
            view.Simple.Size = new Size(500, 50);
            view.Simple.Text = "Completeaza si calculeaza!";
            view.Simple.Font = new Font("Consolas", 13, FontStyle.Bold);
            view.Simple.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.Simple.Anchor = AnchorStyles.None;
        }
        private void loadSimpleButton(int k)
        {
            view.SimpleButton = new IconButton();
            view.SimpleButton.Parent = view;
            view.SimpleButton.Location = new Point(485, 185);
            view.SimpleButton.Size = new Size(200, 125);
            view.SimpleButton.FlatAppearance.BorderSize = 0;
            view.SimpleButton.FlatStyle = FlatStyle.Flat;
            view.SimpleButton.BackColor = Color.Transparent;
            view.SimpleButton.ForeColor = ColorTranslator.FromHtml("#202020");
            view.SimpleButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            view.SimpleButton.Text = "Calculeaza";
            view.SimpleButton.Font = new Font("Consolas", 10, FontStyle.Bold);
            view.Simple.TextAlign = ContentAlignment.MiddleCenter;
            view.SimpleButton.FlatAppearance.MouseOverBackColor = view.SimpleButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            view.SimpleButton.Anchor = AnchorStyles.None;


            view.SimpleButton.Click += delegate (object sender2, EventArgs e2) { this.simpleButton_Click(sender2, e2, k); };
        }
        private void loadPickLabel()
        {
            view.PickNumbers = new Label();
            view.PickNumbers.Parent = view;
            view.PickNumbers.Anchor = AnchorStyles.None;
            view.PickNumbers.Location = new Point(375, 330);
            view.PickNumbers.Size = new Size(500, 50);
            view.PickNumbers.Font = new Font("Consolas", 12, FontStyle.Bold);
            view.PickNumbers.ForeColor = view.Simple.ForeColor;
            view.PickNumbers.Text = "Poti adauga si o multime de numere!";
            view.PickNumbers.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void loadPickButton(int k)
        {
            view.PickButton = new IconButton();
            view.PickButton.Parent = view;
            view.PickButton.Anchor = AnchorStyles.None;
            view.PickButton.Location = new Point(400, 550);
            view.PickButton.Size = new Size(400, 50);
            view.PickButton.FlatStyle = FlatStyle.Flat;
            view.PickButton.FlatAppearance.BorderSize = 0;
            view.PickButton.ForeColor = view.SimpleButton.ForeColor;
            view.PickButton.Font = view.SimpleButton.Font;
            view.PickButton.TextAlign = view.PickButton.ImageAlign = ContentAlignment.MiddleLeft;
            view.PickButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            view.PickButton.FlatAppearance.MouseOverBackColor = view.PickButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            view.PickButton.Text = "Calculeaza + arata rezultate";
            view.PickButton.Anchor = AnchorStyles.None;

            view.PickButton.Click += delegate (object sender2, EventArgs e2) { this.pickButton_Click(sender2, e2, k); };
        }
        private void loadPickResult()
        {
            view.Controls.Remove(view.PickResult);
            view.PickResult = new Panel();
            view.PickResult.AutoScroll = true;
            view.PickResult.Parent = view;
            view.PickResult.Size = new Size(300, 300);
            view.PickResult.Location = new Point(950, 350);
            view.PickResult.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.PickResult.Font = new Font("Consolas", 10, FontStyle.Bold);
            view.PickResult.Anchor = AnchorStyles.None;
            view.PickResult.BorderStyle = BorderStyle.FixedSingle;
        }

        private void simpleButton_Click(object sender, EventArgs e, int k)
        {
            if (view.SimpleButton.ForeColor.Equals(ColorTranslator.FromHtml("#202020")) || view.SimpleButton.IconChar == IconChar.None)
                return;
            view.Controls.Remove(view.SimpleResult);
            view.SimpleResult = new Label();
            view.SimpleResult.Parent = view;
            view.SimpleResult.Size = new Size(250, 100);
            view.SimpleResult.Location = new Point(700, 197);
            view.SimpleResult.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            view.SimpleResult.Anchor = AnchorStyles.None;
            view.SimpleResult.Font = new Font("Consolas", 10, FontStyle.Bold);
            view.SimpleResult.TextAlign = ContentAlignment.MiddleLeft;

            long result = 0;
            if (k == 1)
            {
                Combinari<int> comb = new Combinari<int>(int.Parse(view.Input.K), int.Parse(view.Input.N));
                result = comb.result();
                view.SimpleResult.Text = "Raspuns: " + result.ToString();
            }
            else if (k == 2)
            {
                Aranjamente<int> aranj = new Aranjamente<int>(int.Parse(view.Input.K), int.Parse(view.Input.N));
                result = aranj.result();
                view.SimpleResult.Text = "Raspuns: " + result.ToString();
            }
            else if (k == 3)
            {
                Aranjamente<int> aranj = new Aranjamente<int>(int.Parse(view.Input.K), 0);
                result = aranj.result();
                view.SimpleResult.Text = "Raspuns: " + result.ToString();
            }

            Operation op;
            ControlOperations control = new ControlOperations(100);
            op = new Operation(k, int.Parse(view.Input.K), int.Parse(view.Input.N), view.Username, result, new List<int>(), DateTime.Now);
            control.add(op.Username, op);
        }
        private void pickButton_Click(object sender, EventArgs e, int k)
        {
            if (view.PickButton.IconChar == IconChar.None)
                return;
            string[] values = view.Pick.Textbox.Text.Split(',');
            List<int> v = new List<int>();
            if (k == 1)
            {
                v.Add(-1);
                foreach (string word in values)
                    v.Add(int.Parse(word));
                Combinari<int> comb = new Combinari<int>(v, int.Parse(view.Input.K), int.Parse(view.Input.N));
                comb.back(1);
                loadPickResult();
                comb.loadResults(view.PickResult);
                v.RemoveAt(0);
            }
            else if (k == 2)
            {
                foreach (string word in values)
                    v.Add(int.Parse(word));
                Aranjamente<int> aranj = new Aranjamente<int>(v, int.Parse(view.Input.N));
                aranj.back(0);
                loadPickResult();
                aranj.loadResults(view.PickResult);
            }
            else if (k == 3)
            {
                foreach (string word in values)
                    v.Add(int.Parse(word));
                Aranjamente<int> aranj = new Aranjamente<int>(v, int.Parse(view.Input.K));
                aranj.back(0);
                loadPickResult();
                aranj.loadResults(view.PickResult);
            }

            Operation op;
            ControlOperations control = new ControlOperations(100);
            op = new Operation(k, int.Parse(view.Input.K), int.Parse(view.Input.N), view.Username, -1, v, DateTime.Now);
            control.add(op.Username, op);
        }

    }
}
