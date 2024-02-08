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
    public partial class AddEditCompany : Form
    {
        private Company companyToEdit;
        public MainStaffView mainStaffView;
        public AddEditCompany()
        {
            InitializeComponent();
        }

        public AddEditCompany(MainStaffView mainStaffView): this()
        {
            
            this.mainStaffView = mainStaffView;
        }

       public AddEditCompany(MainStaffView mainStaffView, Company company):this()
        {
            this.mainStaffView = mainStaffView;
            companyToEdit = company; 
            companyTB.Text = company.company_name;
            saveBtn.Text = "Edit";
            this.Text = "Edit Company";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string companyName = companyTB.Text;
            if (companyToEdit != null) 
            {
                CompanyController companyController = new CompanyController();
                companyController.EditCompany(companyToEdit.company_name, companyName);
            }
            else 
            {
                CompanyController companyController = new CompanyController();
                companyController.AddCompany(companyName);
            }
            this.Close();
            mainStaffView.UpdateCompaniesTreeView();

        }
    }
}
