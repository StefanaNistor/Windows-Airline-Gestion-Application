using AirlinePAW.classes;
using AirlinePAW.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinePAW.views
{
    public partial class MainUserView : Form
    {
        
        private int currentPageIndex = 0;
        private string[] routesToPrint;
        private User _user= new User();
        RouteController routesController;
        private string ConnectionToString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
        public MainUserView()
        {
            InitializeComponent();
            InitializeRoutes();
        }

        public MainUserView(User user) : this()
        {
            _user = user;
            InitializeBookings();

        }

        private void bookingBtn_Click(object sender, EventArgs e)
        {
            BookingView bookingView = new BookingView(_user, this);
            bookingView.ShowDialog();
        }

        private void MainUserView_Load(object sender, EventArgs e)
        {

        }

        private void InitializeRoutes()
        {
            routesController = new RouteController();
            List<Route> routes = routesController.GetAllRoutes();
            foreach (Route route in routes)
            {
                ListViewItem item = new ListViewItem(route.RouteId.ToString());
                item.SubItems.Add(route.Origin);
                item.SubItems.Add(route.Destination);
                item.SubItems.Add(route.Distance.ToString());
                item.SubItems.Add(route.Company.company_name);
                routesLV.Items.Add(item);
            }

        }

        //update the listview with the bookings of the user 
        public void UpdateBookingsListView()
        {
            BookingController bookingController = new BookingController();
            List<Booking> bookings = bookingController.GetAllBookingsOfUser(_user.Username);
            bookingsLV.Items.Clear();
            foreach (Booking booking in bookings)
            {
                ListViewItem item = new ListViewItem(booking.BookingId.ToString());
                item.SubItems.Add(booking.Route.Destination);
                item.SubItems.Add(booking.NoPeople.ToString());
                bookingsLV.Items.Add(item);
            }
        }



        private void InitializeBookings()
        {
            BookingController bookingController = new BookingController();
            List<Booking> bookings = bookingController.GetAllBookingsOfUser(_user.Username);
            foreach (Booking booking in bookings)
            {
                ListViewItem item = new ListViewItem(booking.BookingId.ToString());
                item.SubItems.Add(booking.Route.Destination);
                item.SubItems.Add(booking.NoPeople.ToString());
                bookingsLV.Items.Add(item);
            }
        }

        private void bookingsLV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int bookingId = int.Parse(bookingsLV.SelectedItems[0].SubItems[0].Text);
            BookingController bookingController = new BookingController();
            Booking booking = bookingController.GetBookingById(bookingId);
            BookingView bookingView = new BookingView(booking, this, _user);
            bookingView.ShowDialog();

        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            BookingController bookingController = new BookingController();
            List<Booking> bookings = bookingController.GetAllBookingsOfUser(_user.Username);
            bookingController.SerializeBookings(bookings);
            MessageBox.Show("Bookings serialized");

        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingController bookingController = new BookingController();
            List<Booking> bookings = bookingController.DeserializeBookings();
            bookingsLV.Items.Clear();
            foreach (Booking booking in bookings)
            {
                ListViewItem item = new ListViewItem(booking.BookingId.ToString());
                item.SubItems.Add(booking.Route.Destination);
                item.SubItems.Add(booking.NoPeople.ToString());
                bookingsLV.Items.Add(item);
            }
            MessageBox.Show("Bookings deserialized");
        }

        private void printRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RouteController routeController = new RouteController();
            List<Route> routes = routeController.GetAllRoutes();
            List<string> routesStringList = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Route route in routes)
            {
                string routeString = $"{route.RouteId} {route.Origin} {route.Destination} {route.Distance} {route.Company.company_name} \n";
                stringBuilder.Append(routeString);
            }
            routesStringList.Add(stringBuilder.ToString());
            routesToPrint = routesStringList.ToArray();
            printDocument1.DocumentName = "Routes";
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
           //PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
           printPreviewDialog1.Document = printDocument1;
           printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            e.Graphics.MeasureString(routesToPrint[currentPageIndex], this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);
            e.Graphics.DrawString(routesToPrint[currentPageIndex], this.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            currentPageIndex++;
            e.HasMorePages = currentPageIndex < routesToPrint.Length;
            currentPageIndex = 0;
        }

        //LOGOUT BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInView loginView = new LogInView();
            loginView.ShowDialog();
            this.Close();

        }

        private void bookingsLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //do nothing

            //MessageBox.Show("Please double click on the booking ID you want to cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //CANCEL BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            if (bookingsLV.SelectedItems.Count > 0)
            {
                int bookingId = int.Parse(bookingsLV.SelectedItems[0].SubItems[0].Text);
                BookingController bookingController = new BookingController();
                bookingController.DeleteBooking(bookingId);
                bookingsLV.Items.Clear();
                InitializeBookings();
            }
            else
            {
                MessageBox.Show("Please select a booking to cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
