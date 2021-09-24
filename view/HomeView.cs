using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FontAwesome.Sharp;
using System.Windows.Forms;

namespace mathApp.view
{
    class HomeView : View
    {
        private Font font = new Font("Consolas", 15, FontStyle.Bold);
        private Label message;
        private Label time;
        private IconPictureBox picture;
        
        private Timer timer;
        private DateTime currentTime;

        public HomeView(string username, Panel container) : base(username, container)
        {
            loadMessage();
            setTimeLabel();
            setPicture();
            setTimer();
        }

        private void loadMessage()
        {
            message = new Label();
            message.Parent = this;
            message.Anchor = AnchorStyles.None;
            message.Location = new Point(500, 175);
            message.Size = new Size(600, 100);
            message.Font = new Font("Consolas", 12, FontStyle.Bold);
            message.Text = "Incepe sa rezolvi niste probleme\nNu pierde vremea uitandu - te la ceas!";
            message.TextAlign = ContentAlignment.MiddleCenter;
            message.BackColor = Color.Transparent;
            message.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
        }
        private void setTimeLabel()
        {
            time = new Label();
            time.Parent = this;
            time.Location = new Point(500, 450);
            time.Size = new Size(600, 100);
            time.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            time.Font = font;
            time.TextAlign = ContentAlignment.MiddleCenter;
            time.Anchor = AnchorStyles.None;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            currentTime = DateTime.Now;
            time.Text = currentTime.ToString("F");
        }
        private void setTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }
        private void setPicture()
        {
            picture = new IconPictureBox();
            picture.Parent = this;
            picture.Location = new Point(750, 350);
            picture.Anchor = AnchorStyles.None;
            picture.Size = new Size(100, 100);
            picture.IconChar = IconChar.Stopwatch;
            picture.ForeColor = time.ForeColor;
            picture.BackColor = Color.Transparent;
        }

    }
}
