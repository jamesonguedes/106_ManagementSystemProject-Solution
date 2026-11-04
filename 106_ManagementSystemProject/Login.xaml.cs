using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _106_ManagementSystemProject
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        // -----------------------
        // Login Methods
        // -----------------------

        private void AdminDashboard_Click(object sender, RoutedEventArgs e)         
        {                                                                           
            if(txtUsername.Text == "Admin" && txtPassword.Password == "Admin123")                                         
            {                                                                       
                MessageBox.Show("Login successful");
                AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();  
                adminDashboardWindow.Show();
            }                                                                       
            else                                                                    
            {                                                                       
                MessageBox.Show("Please enter your username and password.");       
            }                                                                       
        }

        private void EmployeeDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Employee" && txtPassword.Password == "Employee123")
            {
                MessageBox.Show("Login successful");
                EmployeeDashboardWindow employeeDashboardWindow = new EmployeeDashboardWindow();
                employeeDashboardWindow.Show();
            }
            else
            {
                MessageBox.Show("Please enter your username and password.");
            }
        }

    }
}
