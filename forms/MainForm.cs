using FontAwesome.Sharp;
using mathApp.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mathApp.forms
{
    public partial class MainForm : Form
    {
        private string username;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private Panel pnlAside;
        private IconPictureBox logo;
        private Panel pnlHeader;
        private Panel currentPanel;
        private Label currentTitle;
        private Panel pnlMain;

        private IconButton btnHome;
        private IconButton btnSimple;
        private IconButton btnEcuations;
        private IconButton btnComplex;
        private IconButton btnProfile;
        private IconButton btnHelp;

        private Font font = new Font("Consolas", 10, FontStyle.Bold);

        private Form currentChild;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "";
            this.Width = 1300;
            this.Height = 750;
            this.MinimumSize = this.Size;
            this.SetDesktopLocation(250, 150);
            setAside();
            setHeader();
            setButtons();
            setCurrentPanel();
            setMain();
            currentChild = new HomeView(this.username, pnlMain);
            currentChild.FormBorderStyle = FormBorderStyle.None;
            currentChild.TopLevel = false;
            currentChild.Parent = pnlMain;
            currentChild.BringToFront();
            currentChild.Show();
            this.FormClosed += new FormClosedEventHandler(this.formClosed);
        }


        private void setHeader()
        {
            pnlHeader = new Panel();
            pnlHeader.Parent = this;
            pnlHeader.Location = new Point(350, 0);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Width = this.Width - pnlAside.Width;
            pnlHeader.Height = 100;
            pnlHeader.BackColor = pnlAside.BackColor;

            setLogo();
            setTitle();
        }
        private void setLogo()
        {
            logo = new IconPictureBox();
            logo.Parent = pnlHeader;
            logo.Location = new Point(125, 20);
            logo.Width = 75;
            logo.Height = 75;
            logo.IconChar = IconChar.Calculator;
            logo.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            logo.BackColor = Color.Transparent;
        }
        private void setTitle()
        {
            currentTitle = new Label();
            currentTitle.Parent = this.pnlHeader;
            currentTitle.Anchor = AnchorStyles.None;
            currentTitle.Location = new Point(600, 10);
            currentTitle.Size = new Size(400, 80);
            currentTitle.TextAlign = ContentAlignment.MiddleCenter;
            currentTitle.Font = new Font("Consolas", 12, FontStyle.Bold);
            currentTitle.ForeColor = logo.ForeColor;
            currentTitle.Text = "Acasa - " + this.username;
        }

        private void setAside()
        {
            pnlAside = new Panel();
            pnlAside.Parent = this;
            pnlAside.Dock = DockStyle.Left;
            pnlAside.Width = 350;
            pnlAside.BackColor = ColorTranslator.FromHtml("#202020");
        }
        private void setButtons()
        {
            setBtnSimple();
            setHome();
            setBtnEcuations();
            setBtnProfile();
        }
        private void setBtnSimple()
        {
            btnSimple = new IconButton();
            btnSimple.Parent = pnlAside;
            btnSimple.IconChar = IconChar.PenNib;
            btnSimple.IconColor = logo.ForeColor;
            btnSimple.ImageAlign = ContentAlignment.MiddleLeft;
            btnSimple.Location = new Point(10, 130);
            btnSimple.Width = 340;
            btnSimple.Height = 60;
            btnSimple.TabStop = false;
            btnSimple.Text = "Probleme simple";
            btnSimple.TextAlign = ContentAlignment.MiddleLeft;
            btnSimple.ForeColor = logo.ForeColor;
            btnSimple.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSimple.Font = font;
            btnSimple.FlatStyle = FlatStyle.Flat;
            btnSimple.FlatAppearance.BorderSize = 0;

            btnSimple.Click += new EventHandler(this.moveCurrentPanel);
            btnSimple.Click += new EventHandler(this.changeTitle);
            btnSimple.Click += delegate (object sender2, EventArgs e2) { this.openForm(sender2, e2, new SimpleView(this.username, pnlMain)); };
        }
        private void setHome()
        {
            btnHome = new IconButton();
            btnHome.Parent = pnlAside;
            btnHome.IconChar = IconChar.Home;
            btnHome.IconColor = logo.ForeColor;
            btnHome.ImageAlign = btnSimple.ImageAlign;
            btnHome.Location = new Point(10, 70);
            btnHome.Width = btnSimple.Width;
            btnHome.Height = btnSimple.Height;
            btnHome.TabStop = btnSimple.TabStop;
            btnHome.Text = "Acasa";
            btnHome.TextAlign = btnSimple.TextAlign;
            btnHome.ForeColor = logo.ForeColor;
            btnHome.TextImageRelation = btnSimple.TextImageRelation;
            btnHome.Font = font;
            btnHome.FlatStyle = btnSimple.FlatStyle; ;
            btnHome.FlatAppearance.BorderSize = btnSimple.FlatAppearance.BorderSize;

            btnHome.Click += new EventHandler(this.moveCurrentPanel);
            btnHome.Click += new EventHandler(this.changeTitle);
            btnHome.Click += delegate (object sender2, EventArgs e2) { this.openForm(sender2, e2, new HomeView(this.username, pnlMain)); };
        }
        private void setBtnEcuations()
        {
            btnEcuations = new IconButton();
            btnEcuations.Parent = pnlAside;
            btnEcuations.IconChar = IconChar.Times;
            btnEcuations.IconColor = logo.ForeColor;
            btnEcuations.ImageAlign = btnSimple.ImageAlign;
            btnEcuations.Location = new Point(10, 190);
            btnEcuations.Width = btnSimple.Width;
            btnEcuations.Height = btnSimple.Height;
            btnEcuations.TabStop = btnSimple.TabStop;
            btnEcuations.Text = "Ecuatii";
            btnEcuations.TextAlign = btnSimple.TextAlign;
            btnEcuations.ForeColor = logo.ForeColor;
            btnEcuations.TextImageRelation = btnSimple.TextImageRelation;
            btnEcuations.Font = font;
            btnEcuations.FlatStyle = btnSimple.FlatStyle; ;
            btnEcuations.FlatAppearance.BorderSize = btnSimple.FlatAppearance.BorderSize;

            btnEcuations.Click += new EventHandler(this.moveCurrentPanel);
            btnEcuations.Click += new EventHandler(this.changeTitle);
            btnEcuations.Click += delegate (object sender2, EventArgs e2) { this.openForm(sender2, e2, new EcuationView(username, pnlMain)); };
        }
        private void setBtnComplex()
        {
            btnComplex = new IconButton();
            btnComplex.Parent = pnlAside;
            btnComplex.IconChar = IconChar.PenAlt;
            btnComplex.IconColor = logo.ForeColor;
            btnComplex.ImageAlign = btnSimple.ImageAlign;
            btnComplex.Location = new Point(10, 250);
            btnComplex.Width = btnSimple.Width;
            btnComplex.Height = btnSimple.Height;
            btnComplex.TabStop = btnSimple.TabStop;
            btnComplex.Text = "Probleme complexe";
            btnComplex.TextAlign = btnSimple.TextAlign;
            btnComplex.ForeColor = logo.ForeColor;
            btnComplex.TextImageRelation = btnSimple.TextImageRelation;
            btnComplex.Font = font;
            btnComplex.FlatStyle = btnSimple.FlatStyle; ;
            btnComplex.FlatAppearance.BorderSize = btnSimple.FlatAppearance.BorderSize;

            btnComplex.Click += new EventHandler(this.moveCurrentPanel);
            btnComplex.Click += new EventHandler(this.changeTitle);
        }
        private void setBtnProfile()
        {
            btnProfile = new IconButton();
            btnProfile.Parent = pnlAside;
            btnProfile.IconChar = IconChar.User;
            btnProfile.IconColor = logo.ForeColor;
            btnProfile.ImageAlign = btnSimple.ImageAlign;
            btnProfile.Location = new Point(10, 250);
            btnProfile.Width = btnSimple.Width;
            btnProfile.Height = btnSimple.Height;
            btnProfile.TabStop = btnSimple.TabStop;
            btnProfile.Text = "Profilul meu";
            btnProfile.TextAlign = btnSimple.TextAlign;
            btnProfile.ForeColor = logo.ForeColor;
            btnProfile.TextImageRelation = btnSimple.TextImageRelation;
            btnProfile.Font = font;
            btnProfile.FlatStyle = btnSimple.FlatStyle; ;
            btnProfile.FlatAppearance.BorderSize = btnSimple.FlatAppearance.BorderSize;

            btnProfile.Click += new EventHandler(this.moveCurrentPanel);
            btnProfile.Click += new EventHandler(this.changeTitle);
            btnProfile.Click += delegate (object sender2, EventArgs e2) { this.openForm(sender2, e2, new ProfileView(username, pnlMain)); };
        }
        private void setBtnHelp()
        {
            btnHelp = new IconButton();
            btnHelp.Parent = pnlAside;
            btnHelp.IconChar = IconChar.QuestionCircle;
            btnHelp.IconColor = logo.ForeColor;
            btnHelp.ImageAlign = btnSimple.ImageAlign;
            btnHelp.Location = new Point(10, 370);
            btnHelp.Width = btnSimple.Width;
            btnHelp.Height = btnSimple.Height;
            btnHelp.TabStop = btnSimple.TabStop;
            btnHelp.Text = "Ajutor";
            btnHelp.TextAlign = btnSimple.TextAlign;
            btnHelp.ForeColor = logo.ForeColor;
            btnHelp.TextImageRelation = btnSimple.TextImageRelation;
            btnHelp.Font = font;
            btnHelp.FlatStyle = btnSimple.FlatStyle; ;
            btnHelp.FlatAppearance.BorderSize = btnSimple.FlatAppearance.BorderSize;

            btnHelp.Click += new EventHandler(this.moveCurrentPanel);
            btnHelp.Click += new EventHandler(this.changeTitle);
        }
        private void setCurrentPanel()
        {
            currentPanel = new Panel();
            currentPanel.Parent = this.pnlAside;
            currentPanel.Location = new Point(0, 70);
            currentPanel.Size = new Size(10, 60);
            currentPanel.BackColor = ColorTranslator.FromHtml("#707070");
        }

        private void setMain()
        {
            pnlMain = new Panel();
            pnlMain.Parent = this;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BackColor = ColorTranslator.FromHtml("#3F3F3F");
        }

        private void moveCurrentPanel(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            currentPanel.Location = new Point(0, button.Location.Y);
        }
        private void changeTitle(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            currentTitle.Text = button.Text + " - " + this.username;
        }
        private void openForm(object sender, EventArgs e,Form form)
        {
            if(currentChild != null)
            {
                currentChild.Close();
            }
            currentChild = form;
            currentChild.FormBorderStyle = FormBorderStyle.None;
            currentChild.TopLevel = false;
            currentChild.Parent = pnlMain;
            currentChild.BringToFront();
            currentChild.Show();
        }
        private void formClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
