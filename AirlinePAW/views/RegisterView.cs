using AirlinePAW.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinePAW.views
{
    public partial class RegisterView : Form
    {
        private UserController userController;
        private string ConnectionToString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
        public RegisterView()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            int role = checkStaff.Checked ? 1 : 0;
            bool isValid = ValidateInputs(username, password);

            if (isValid)
            {
                // Call the registration logic from the UserController
                bool registrationSuccess = userController.RegisterUser(username, password, role);

                if (registrationSuccess)
                {
                   
                    this.Hide();

                    // Open the main user view
                    if (checkStaff.Checked)
                    {
                        MainStaffView mainStaffView = new MainStaffView();
                        mainStaffView.ShowDialog();
                    }
                    else
                    {
                        MainUserView mainUserView = new MainUserView();
                        mainUserView.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInputs(string username, string password)
        {
            bool isValid = true;

            errorProviderRegistration.Clear();

            if (string.IsNullOrWhiteSpace(username))
            {
                errorProviderRegistration.SetError(usernameTB, "Username cannot be empty");
                isValid = false;
            }
            if (password.Length < 3)
            {
                errorProviderRegistration.SetError(passwordTB, "Password must be at least 3 characters long");
                isValid = false;
            }
            return isValid;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            LogInView loginView = new LogInView();
            loginView.ShowDialog();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {

        }
    }
}
