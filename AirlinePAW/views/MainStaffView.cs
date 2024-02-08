using AirlinePAW.classes;
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
    public partial class MainStaffView : Form
    {
        private User _user= new User();
        private UserController userController = new UserController();
        private RouteController routeController = new RouteController();
        private BookingController bookingController = new BookingController();
        private CompanyController companyController = new CompanyController();
        private string ConnectionToString = "Data Source=database.db";
        public MainStaffView()
        {
            InitializeComponent();
            InitializeUsers();
            InitializeRoutes();
            InitializeBookings();
            InitializeCompanies();
        }

        public MainStaffView(User user):this() {
            _user = user;
        }

        public void InitializeRoutes()
        {
          
            routesDV.ColumnCount = 5;
            routesDV.Columns[0].Name = "ID";
            routesDV.Columns[1].Name = "Origin";
            routesDV.Columns[2].Name = "Destination";
            routesDV.Columns[3].Name = "Distance";
            routesDV.Columns[4].Name = "Company";

            
            var routes = routeController.GetAllRoutes();
            foreach (var route in routes)
            {
                routesDV.Rows.Add(route.RouteId, route.Origin, route.Destination, route.Distance, route.Company.company_name);
            }
        }

        public void InitializeUsers()
        {
            
            usersDV.ColumnCount = 2;
            usersDV.Columns[0].Name = "ID";
            usersDV.Columns[1].Name = "Username";
            

            var users = userController.GetUsersNotStaff();
            foreach (var user in users)
            {
                usersDV.Rows.Add(user.UserId, user.Username);

            }
        }

        public void InitializeBookings()
        {
            
            bookingsDV.ColumnCount = 5;
            bookingsDV.Columns[0].Name = "ID";
            bookingsDV.Columns[1].Name = "Booking ID";
            bookingsDV.Columns[2].Name = "No of People";
            bookingsDV.Columns[3].Name = "Departure";
            bookingsDV.Columns[4].Name = "Arrival";

           
        
            var bookings = bookingController.GetAllBoookings();
            foreach (var booking in bookings)
            {
                bookingsDV.Rows.Add(booking.User.Username, booking.BookingId, booking.  NoPeople, booking.Route.Origin, booking.Route.Destination);
            }
        }

        public void InitializeCompanies()
        {
    
            var companies = companyController.GetAllCompanies();
            foreach (var company in companies)
            {
                companyTV.Nodes.Add(company.company_name);
            }
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        //ADD BOOKING BUTTON
        private void button4_Click(object sender, EventArgs e)
        {
            BookingView bookingView = new BookingView(_user, this);
            bookingView.ShowDialog();
        }

        private void MainStaffView_Load(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var user = _user.Username;
            var statusText = string.Format("Date: {0} || User: {1}", date, user);
            statusStrip1.Items.Add(statusText);

        }

        private void addRouteBtn_Click(object sender, EventArgs e)
        {

            AddEditRoute addRouteView = new AddEditRoute(this);
            addRouteView.ShowDialog();

        }

        private void addCompanyBtn_Click(object sender, EventArgs e)
        {

            AddEditCompany addEditCompanyForm = new AddEditCompany(this); 
            addEditCompanyForm.ShowDialog();
        }

        private void deleteCompanyBtn_Click(object sender, EventArgs e)
        {

            var selectedNode = companyTV.SelectedNode;
            if (selectedNode != null)
            {
                companyController.DeleteCompany(selectedNode.Text);
                companyTV.Nodes.Remove(selectedNode);
            }
        }

        private void companyTV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            var selectedNode = companyTV.SelectedNode;
            if (selectedNode != null)
            {
                
              var company = companyController.GetCompanyByName(selectedNode.Text);
                
                AddEditCompany addEditCompanyForm = new AddEditCompany(this, company);
                addEditCompanyForm.ShowDialog();
            }
        }


        public void UpdateCompaniesTreeView()
        {
            companyTV.Nodes.Clear();
            var companies = companyController.GetAllCompanies();
            foreach (var company in companies)
            {
                companyTV.Nodes.Add(company.company_name);
            }
        }

        public void UpdateBookingsDataGridView()
        {
            bookingsDV.Rows.Clear();
            var bookings = bookingController.GetAllBoookings();
            foreach (var booking in bookings)
            {
                bookingsDV.Rows.Add(booking.User.Username, booking.BookingId, booking.NoPeople, booking.Route.Origin, booking.Route.Destination);
            }
        }

        public void UpdateRoutesDataGridView()
        {
            routesDV.Rows.Clear();
            var routes = routeController.GetAllRoutes();
            foreach (var route in routes)
            {
                routesDV.Rows.Add(route.RouteId, route.Origin, route.Destination, route.Distance, route.Company.company_name);
            }
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            
            var selectedRow = usersDV.SelectedRows[0];
            var userId = Convert.ToInt32(selectedRow.Cells[0].Value);
            userController.DeleteUser(userId);
            usersDV.Rows.Remove(selectedRow);

        }

        private void deleteBookingBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = bookingsDV.SelectedRows[0];
            var bookingId = Convert.ToInt32(selectedRow.Cells[1].Value);
            bookingController.DeleteBooking(bookingId);
            bookingsDV.Rows.Remove(selectedRow);
        }

        private void deleteFlightBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = routesDV.SelectedRows[0];
            var routeId = Convert.ToInt32(selectedRow.Cells[0].Value);
            routeController.DeleteRoute(routeId);
            routesDV.Rows.Remove(selectedRow);

        }

        private void routesDV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
 
            var selectedRow = routesDV.SelectedRows[0];
            var routeId = Convert.ToInt32(selectedRow.Cells[0].Value);
            var route = routeController.GetRouteById(routeId);
            
            AddEditRoute addEditRouteForm = new AddEditRoute(route, this);
            addEditRouteForm.ShowDialog();


        }

        //LOG OUT BUTTON
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInView loginForm = new LogInView();
            loginForm.ShowDialog();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //nothing
          
        }

        private void companyTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //nothing
        }
    }
}
