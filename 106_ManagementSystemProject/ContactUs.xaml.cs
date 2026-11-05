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
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : Page
    {
        public ContactUs()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" && txtEmail.Text == "" && txtMessage.Text != "")
            {
                MessageBox.Show("Please enter your name, email and message.");
            }
            else
            {
                MessageBox.Show("Your message has been submitted.");

                // Clear the form
                txtName.Clear();
                txtEmail.Clear();
                txtMessage.Clear();
            }
        }
    }
}
