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
using System.Windows.Shapes;

namespace _106_ManagementSystemProject
{

    public partial class EmployeeDashboardWindow : Window
    {
        public EmployeeDashboardWindow(Employee employee)
        {
            InitializeComponent();

            txtEmployeeName.Text = employee.FirstName + " " + employee.LastName;
            txtEmployeeRole.Text = "Job Title: " + employee.JobTitle;
            txtEmployeeEmail.Text = "Email: " + employee.Email;
            txtEmployeePhone.Text = "Phone: " + employee.Phone;
            txtEmployeeDepartment.Text = "Department: " + employee.Department;
        }

        private void RequestLeeave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Maintenance");

        }
        private void UpdateLeave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Maintenance");

        }

        private void DeleteLeave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Maintenance");

        }

        private void dgManageEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MessageBox.Show("Under Maintenance");

            //            Employee selectedEmployee = dgLeaveRequests.SelectedItem as Employee;
            //
            //            if (selectedEmployee == null)
            //            {
            //                return;
            //            }

            //            txtLeaveType.Text = selectedEmployee.FirstName;
            //            txtStartDate.Text = selectedEmployee.LastName;
            //            txtEndDate.Text = selectedEmployee.Email;
            //            txtHoursRequested.Text = selectedEmployee.Phone;
            //            txtStatus.Text = selectedEmployee.JobTitle;
            //            -->
        }

    }
}
