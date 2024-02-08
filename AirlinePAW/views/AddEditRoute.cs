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
    public partial class AddEditRoute : Form
    {
        public MainStaffView mainStaffView;
        public Route _route;
        public Route routeEdit;
        public AddEditRoute()
        {
            InitializeComponent();
            PopulateCombobox();
        }


        public AddEditRoute(MainStaffView mainStaffView) : this()
        {
            this.mainStaffView = mainStaffView;
        }

        public AddEditRoute(Route route, MainStaffView mainStaffView):this()
        {
            this.mainStaffView = mainStaffView;
            _route = route;
            routeEdit = route;
            
            departureTB.Text = route.Origin;
            destinationTB.Text = route.Destination;
            distanceNumeric.Text = route.Distance.ToString();
            comboBoxCompany.Text = route.Company.company_name;
            saveBtn.Text = "Edit";
            this.Text = "Edit Route";

        }

        public void PopulateCombobox()
        {
            CompanyController companyController = new CompanyController();
            List<Company> companies = companyController.GetAllCompanies();
            foreach (Company company in companies)
            {
                comboBoxCompany.Items.Add(company.company_name);
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
           
            string origin = departureTB.Text;
            string destination = destinationTB.Text;
            double distance = Convert.ToDouble(distanceNumeric.Text);
            string company = comboBoxCompany.Text;

            CompanyController companyController = new CompanyController();
            Company companyObj = companyController.GetCompanyByName(company);

            if (routeEdit != null) 
            {
                routeEdit.Origin = origin;
                routeEdit.Destination = destination;
                routeEdit.Distance = distance;
                routeEdit.Company = companyObj;

                RouteController routeController = new RouteController();
                routeController.UpdateRoute(routeEdit);
            }
            else 
            {
            
                Route route = new Route(origin, destination, distance, companyObj);
                RouteController routeController = new RouteController();
                routeController.AddRoute(route);
            }

            this.Close();
            mainStaffView.UpdateRoutesDataGridView();

        }

        private void comboBoxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddEditRoute_Load(object sender, EventArgs e)
        {

        }
    }
}
