using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathApp.model;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;

namespace mathApp.view
{
    class HistoryCard : Panel
    {
        private Operation operation;
        public Operation OPERATIONS { get => this.operation; set => this.operation = value; }
        private ProfileView view;

        private HistoryCardIcon icon;
        private Label result;
        private Label numbers;
        private IconPictureBox calendar;
        private Label date;

        public HistoryCard(Operation op, ProfileView view)
        {
            this.operation= op;
            this.view = view;
            this.Parent = view;
            this.Size = new Size(750, 200);
            this.BorderStyle = BorderStyle.FixedSingle;
        }
        public void setLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }
        public void load()
        {
            loadIcon();
            if (operation.Values.Count == 0)
                loadResult();
            else loadNumbers();
            loadDate();
        }

        private void loadIcon()
        {
            icon = new HistoryCardIcon(operation, this);
            icon.setLocation(10, 25);
            icon.loadIcon();
        }
        private void loadResult()
        {
            result = new Label();
            result.Parent = this;
            result.Size = new Size(300, 150);
            result.Location = new Point(icon.Location.X + 160, icon.Location.Y);
            result.Text = "Rezultat:\n" + operation.Result.ToString();
            result.ForeColor = ColorTranslator.FromHtml("#FFDF6C");
            result.Font = new Font("Consolas", 15, FontStyle.Bold);
            result.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void loadNumbers()
        {
            numbers = new Label();
            numbers.Parent = this;
            numbers.Location = new Point(icon.Location.X + 160, icon.Location.Y);
            numbers.Size = new Size(300, 150);
            numbers.Font = new Font("Consolas", 12, FontStyle.Bold);
            numbers.Text = "In multimea:\n{";
            numbers.TextAlign = ContentAlignment.MiddleCenter;
            numbers.ForeColor = ColorTranslator.FromHtml("#FFDF6C");

            List<int> v = operation.Values;
            string res = string.Empty;
            foreach (int value in v)
                res += value.ToString() + ",";
            res = res.Remove(res.Length - 1, 1);
            numbers.Text += res + "}";
            
        }
        private void loadCalendar()
        {
            calendar = new IconPictureBox();
            calendar.Parent = date;
            calendar.Size = new Size(75, 75);
            calendar.Location = new Point(85, 5);
            calendar.IconChar = IconChar.CalendarDay;
            calendar.IconColor = ColorTranslator.FromHtml("#FFDF6C");
        }
        private void loadDate()
        {
            date = new Label();
            date.Parent = this;
            date.Location = new Point(icon.Location.X + 470, icon.Location.Y);
            date.Size = new Size(250, 150);
            date.Font = new Font("Consolas", 11, FontStyle.Bold);
            date.TextAlign = ContentAlignment.BottomCenter;
            date.ForeColor = ColorTranslator.FromHtml("#FFDF6C");

            loadCalendar();
            date.Text = operation.Time.ToString("f");
        }

    }
}
