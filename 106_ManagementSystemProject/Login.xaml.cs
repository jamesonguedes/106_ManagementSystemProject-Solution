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

        // This method below is referent to the temporary button on the Login page
        // so it can be deleted later
        // ------------------------------------------------------------------------
        private void AdminDashboard_Click(object sender, RoutedEventArgs e)         // DELETE LATER
        {                                                                           // DELETE LATER
            AdminDashboardWindow dashboard = new AdminDashboardWindow();            // DELETE LATER
            dashboard.Show();                                                       // DELETE LATER
        }                                                                           // DELETE LATER
        // ------------------------------------------------------------------------
    }
}
