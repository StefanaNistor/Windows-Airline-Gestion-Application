using AirlinePAW.classes;
using AirlinePAW.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinePAW.views
{
    public partial class BookingView : Form

    {
        MainStaffView mainStaffView = new MainStaffView();
        MainUserView userView = new MainUserView();
        private User _user= new User();
        private Booking _booking;
        private RouteController _routeController= new RouteController();
        private string ConnectionToString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
        public BookingView()
        {
            InitializeComponent();
            PopulateComboBox();
        }
        public BookingView(User user, MainStaffView mainview) : this()
        {
            _user = user;
            mainStaffView = mainview;
        }

        public BookingView(Booking booking, MainUserView userView, User user) : this()
        {
            _booking= booking;
            this.userView = userView;
            _user = user;
            _booking.User= user;


            comboBox1.Text = booking.Route.Destination;
            numericPeople.Value = booking.NoPeople;

        }


        public BookingView(User user, MainUserView mainUserView):this()
        {
            _user = user;
            userView = mainUserView;
        }

        public void PopulateComboBox()
        {
            //populate the combobox with the routes
            var routes = _routeController.GetAllRoutes();
            comboBox1.DataSource = routes;
            comboBox1.DisplayMember = "Destination";
            comboBox1.ValueMember = "RouteId";
            comboBox1.SelectedIndex = 0;

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            //int seats = (int)numericPeople.Value;
            //int routeId = (int)comboBox1.SelectedValue;

            Route route = (Route)comboBox1.SelectedItem;
            int seats = (int)numericPeople.Value;
            int routeId = route.RouteId;
            int userID= _user.UserId;

            BookingController bookingController = new BookingController();
            Booking booking = new Booking();

            if (_booking != null)
            { 
                _booking.Route.RouteId = routeId;
                _booking.NoPeople = seats;
                _booking.User.UserId = userID;
                bookingController.UpdateBooking(_booking);      
            }
            else
            {
                booking = bookingController.CreateBooking(_user, routeId, seats);
                bookingController.AddBooking(booking);
            }

            if (_user.Role)
            {
                mainStaffView.UpdateBookingsDataGridView();
            }
            else
            {
                userView.UpdateBookingsListView();
            }
            mainStaffView.UpdateBookingsDataGridView();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
  

        }

        private void BookingView_Load(object sender, EventArgs e)
        {

        }
    }
}
