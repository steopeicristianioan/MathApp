using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Drawing;
using mathApp.service;

namespace mathApp.view
{
    class SimpleView : View
    {
        private SimpleService service;

        //start options
        #region
        private Panel options;
        private IconButton comb;
        private IconButton ar;
        private IconButton perm;
        #endregion

        //operations
        #region
        private PickNumbers pick;
        public PickNumbers Pick { get => this.pick; set => this.pick = value; }
        private PictureBox formula;
        public PictureBox Formula { get => this.formula; set => this.formula = value; }
        private Input input;
        public Input Input { get => this.input; set => this.input = value; }
        private Label simple;
        public Label Simple { get => this.simple; set => this.simple = value; }
        private IconButton simpleButton;
        public IconButton SimpleButton { get => this.simpleButton; set => this.simpleButton = value; }
        private Label pickNumbers;
        public Label PickNumbers { get => this.pickNumbers; set => this.pickNumbers = value; }
        private IconButton pickButton;
        public IconButton PickButton { get => this.pickButton; set => this.pickButton = value; }
        private Label simpleResult;
        public Label SimpleResult { get => this.simpleResult; set => this.simpleResult = value; }
        private Panel pickResult;
        public Panel PickResult { get => this.pickResult; set => this.pickResult = value; }
        #endregion

        private Font font = new Font("Consolas", 13, FontStyle.Bold);
        
        public SimpleView(string username, Panel parent) : base(username, parent)
        {
            service = new SimpleService(this);
            setOptions();
        }

        //start options
        #region
        private void setOptions()
        {
            options = new Panel();
            options.Parent = this;
            options.Dock = DockStyle.Fill;
            options.BackColor = Color.Transparent;

            setOptionButtons();
        }
        private void setOptionButtons()
        {
            comb = new IconButton();
            ar = new IconButton();
            perm = new IconButton();

            comb.Parent = ar.Parent = perm.Parent = options;
            comb.Size = ar.Size = perm.Size = new Size(250, 100);
            comb.Anchor = ar.Anchor = perm.Anchor = AnchorStyles.None;
            comb.Font = ar.Font = perm.Font = font;
            comb.TextImageRelation = ar.TextImageRelation = perm.TextImageRelation = TextImageRelation.ImageBeforeText;
            comb.FlatStyle = ar.FlatStyle = perm.FlatStyle = FlatStyle.Flat;
            comb.FlatAppearance.BorderSize = ar.FlatAppearance.BorderSize = perm.FlatAppearance.BorderSize = 0;
            comb.IconColor = ar.IconColor = perm.IconColor = ColorTranslator.FromHtml("#FFDF6C");
            comb.ForeColor = ar.ForeColor = perm.ForeColor = ColorTranslator.FromHtml("#202020");
            comb.TabStop = ar.TabStop = perm.TabStop = false;
            comb.BackColor = ar.BackColor = perm.BackColor = Color.Transparent;
            comb.ImageAlign = ar.ImageAlign = perm.ImageAlign = ContentAlignment.MiddleLeft;
            comb.FlatAppearance.MouseOverBackColor = ar.FlatAppearance.MouseOverBackColor = perm.FlatAppearance.MouseOverBackColor = Color.Transparent;
            comb.FlatAppearance.MouseDownBackColor = ar.FlatAppearance.MouseDownBackColor = perm.FlatAppearance.MouseDownBackColor = Color.Transparent;

            setComb();
            setAr();
            setPerm();
        }
        private void setComb()
        {
            comb.Location = new Point(675, 200);
            comb.Text = "Combinari";
            comb.IconChar = IconChar.Copyright;
            comb.MouseHover += new EventHandler(this.optionButton_Hover);
            comb.MouseLeave += new EventHandler(this.optionButton_Leave);
            comb.Click += new EventHandler(service.combinari_Click);
        }
        private void setAr()
        {
            ar.Location = new Point(675, 310);
            ar.Text = "Aranjamente";
            ar.IconChar = IconChar.Font;
            ar.MouseHover += new EventHandler(this.optionButton_Hover);
            ar.MouseLeave += new EventHandler(this.optionButton_Leave);
            ar.Click += new EventHandler(service.aranjamente_Click);
        }
        private void setPerm()
        {
            perm.Location = new Point(675, 420);
            perm.Text = "Permutari";
            perm.IconChar = IconChar.ProductHunt;
            perm.MouseHover += new EventHandler(this.optionButton_Hover);
            perm.MouseLeave += new EventHandler(this.optionButton_Leave);
            perm.Click += new EventHandler(service.permutari_Click);
        }
        private void optionButton_Hover(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            button.IconColor = ColorTranslator.FromHtml("#202020");
            button.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
        }
        private void optionButton_Leave(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            button.IconColor = ColorTranslator.FromHtml("#FFDF6C");
            button.ForeColor = ColorTranslator.FromHtml("#202020");
        }
        #endregion

    }
}
