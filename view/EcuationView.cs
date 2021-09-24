using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using mathApp.view;
using FontAwesome.Sharp;
using mathApp.service;

namespace mathApp.view
{
    class EcuationView : View
    {
        private EcuationService service;

        private IconButton getK;
        private IconButton getN;

        public EcuationView(string username, Panel parent) : base(username, parent)
        {
            service = new EcuationService(this);
            loadCommon();
            loadGetK();
            loadGetN();
        }

        private EcInput ec1;
        public EcInput EC1 { get => this.ec1; set => this.ec1 = value; }
        private EcInput ec2;
        public EcInput EC2 { get => this.ec2; set => this.ec2 = value; }
        private IconButton b1;
        public IconButton B1 { get => this.b1; set => this.b1 = value; }
        private IconButton b2;
        public IconButton B2 { get => this.b2; set => this.b2 = value; }
        private Label r1;
        public Label R1 { get => this.r1; set => this.r1 = value; }
        private Label r2;
        public Label R2 { get => this.r2; set => this.r2 = value; }
        private Label message;
        public Label Message { get => this.message; set => this.message = value; }

        private void loadCommon()
        {
            getK = new IconButton();
            getN = new IconButton();

            getK.Parent = getN.Parent = this;
            getK.Size = getN.Size = new Size(750, 150);
            getK.FlatStyle = getN.FlatStyle = FlatStyle.Flat;
            getK.FlatAppearance.BorderSize = getN.FlatAppearance.BorderSize = 0;
            getK.FlatAppearance.MouseOverBackColor = getN.FlatAppearance.MouseOverBackColor = Color.Transparent;
            getK.FlatAppearance.MouseDownBackColor = getN.FlatAppearance.MouseDownBackColor = Color.Transparent;
            getK.ForeColor = getN.ForeColor = ColorTranslator.FromHtml("#202020");
            getK.IconColor = getN.IconColor = ColorTranslator.FromHtml("#FFDF6C");
            getK.TextImageRelation = getN.TextImageRelation = TextImageRelation.ImageBeforeText;
            getK.ImageAlign = getK.TextAlign = getN.ImageAlign = getN.TextAlign = ContentAlignment.MiddleCenter;
            getK.Font = getN.Font = new Font("Consolas", 13, FontStyle.Bold);
            getK.Anchor = getN.Anchor = AnchorStyles.None;

            getK.MouseHover += new EventHandler(this.Button_Hover);
            getN.MouseHover += new EventHandler(this.Button_Hover);

            getK.MouseLeave += new EventHandler(this.Button_Leave);
            getN.MouseLeave += new EventHandler(this.Button_Leave);
        }
        private void loadGetK()
        {
            getK.Location = new Point(500, 200);
            getK.IconChar = IconChar.KickstarterK;
            getK.Text = "Afla k completand rezultatul si n";
            getK.Click += new EventHandler(service.k_Click);
        }
        private void loadGetN()
        {
            getN.Location = new Point(500, 360);
            getN.IconChar = IconChar.Neos;
            getN.Text = "Afla n completand rezultatul si k";
            getN.Click += new EventHandler(service.n_Click);
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
