using AirlinePAW.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinePAW.views
{
    public partial class StatisticsView : Form
    {
        private int[] data;
        BookingController bookingController = new BookingController();
        RouteController routeController = new RouteController();
        CompanyController companyController = new CompanyController();
        UserController userController = new UserController();


        public StatisticsView()
        {
            InitializeComponent();
            Text = "Statistics View";
            ClientSize = new Size(400, 300);
            GetData();
 
        }

        private void GetData()
        {
            data = new int[4];
            data[0] = bookingController.GetAllBookings().Count;
            data[1] = routeController.GetAllRoutes().Count;
            data[2] = companyController.GetAllCompanies().Count;
            data[3] = userController.GetAllUsers().Count;

        }

     

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            int chartWidth = ClientSize.Width - 40; 
            int chartHeight = ClientSize.Height - 25; 
            int barWidth = chartWidth / data.Length; 
            int maxValue = GetMaxValue(data); 

            Pen axisPen = new Pen(Color.Black, 2);
            graphics.DrawLine(axisPen, 20, 20, 20, chartHeight + 20); 
            graphics.DrawLine(axisPen, 20, chartHeight + 50, chartWidth + 50, chartHeight + 50); 


            Brush[] barBrushes = { Brushes.BlueViolet, Brushes.CornflowerBlue, Brushes.Aquamarine, Brushes.CadetBlue }; 
            string[] labels = { "Bookings", "Routes", "Companies", "Users" }; 

            for (int i = 0; i < data.Length; i++)
            {
                int barHeight = (int)((float)data[i] / maxValue * chartHeight);
                int x = 30 + i * barWidth;
                int y = chartHeight + 50 - barHeight;
                graphics.FillRectangle(barBrushes[i], x, y, barWidth - 5, barHeight);
 
                Font labelFont = new Font(FontFamily.GenericSansSerif, 10);
                SizeF labelSize = graphics.MeasureString(labels[i], labelFont);
                float labelX = x + (barWidth - labelSize.Width) / 2;
                float labelY = y - labelSize.Height - 5;
                graphics.DrawString(labels[i], labelFont, Brushes.Black, labelX, labelY);
            }
        }

        private int GetMaxValue(int[] array)
        {
            int maxValue = int.MinValue;
            foreach (int value in array)
            {
                if (value > maxValue)
                    maxValue = value;
            }
            return maxValue;
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInView logInView = new LogInView();
            logInView.ShowDialog();
            this.Close();
        }

        private void StatisticsView_Load(object sender, EventArgs e)
        {

        }
    }
}
