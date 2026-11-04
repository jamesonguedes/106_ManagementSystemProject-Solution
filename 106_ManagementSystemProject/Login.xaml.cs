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
            if(txtAdminEmail.Text == "admin@example.com" && txtAdminPassword.Password == "Admin123")                                         
            {                                                                       
                MessageBox.Show("Login successful");
                AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();  
                adminDashboardWindow.Show();
            }                                                                       
            else                                                                    
            {                                                                       
                MessageBox.Show("Please enter your admin email and password.");       
            }                                                                       
        }

        private void EmployeeDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeeEmail.Text == "employee@example.com" && txtEmployeePassword.Password == "Employee123")
            {
                MessageBox.Show("Login successful");
                EmployeeDashboardWindow employeeDashboardWindow = new EmployeeDashboardWindow();
                employeeDashboardWindow.Show();
            }
            else
            {
                MessageBox.Show("Please enter your employee email and password.");
            }
        }
    }
}
