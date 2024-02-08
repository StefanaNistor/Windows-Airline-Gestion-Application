using AirlinePAW.classes;
using AirlinePAW.controllers;
using AirlinePAW.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinePAW
{
    
    public partial class LogInView : Form
    {
        private User user = new User();
        private  UserController userController;
        private string ConnectionToString= "Data Source=database.db";
        public LogInView()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            bool role= checkStaff.Checked;

            user= userController.GetUser(username, password, role);
        
            if (userController.AuthenticateUser(username, password, role))
            {
                
                this.Hide();
                if (checkStaff.Checked)
                {
                    
                    MainStaffView mainStaffView = new MainStaffView(user);
                    mainStaffView.ShowDialog();
                    this.Close();
                }
                else
                {
                    
                    MainUserView mainUserView = new MainUserView(user);
                    mainUserView.ShowDialog();
                    this.Close();
                }
            }
            else
            {
               
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
          
            RegisterView registrationForm = new RegisterView();
            registrationForm.ShowDialog();
            this.Close(); 
        }

        private void LogInView_Load(object sender, EventArgs e)
        {
          
            contextMenuStrip1.Show();
            label4.ContextMenuStrip = contextMenuStrip1;
            label4.Click += new EventHandler(label4_Click);

            passwordTB.PasswordChar = '*';

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
      
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            GiveRatingView ratingForm = new GiveRatingView();
            ratingForm.ShowDialog();
            this.Close();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
            contextMenuStrip1.Show(label4, new Point(0, label4.Height));
        }

        private void seeStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatisticsView statisticsForm = new StatisticsView();
            statisticsForm.ShowDialog();
            this.Close();
        }
    }
}
