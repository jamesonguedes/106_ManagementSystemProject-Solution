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

            txtEmployeeId.Text = "Employee ID: " + employee.Id.ToString();
            txtEmployeeName.Text = employee.FirstName + " " + employee.LastName;
            txtEmployeeRole.Text = "Job Title: " + employee.JobTitle;
            txtEmployeeEmail.Text = "Email: " + employee.Email;
            txtEmployeePhone.Text = "Phone: " + employee.Phone;
            txtEmployeeDepartment.Text = "Department: " + employee.Department;
        }

        private void RequestLeeave_Click(object sender, RoutedEventArgs e)
        {
            string leaveType = txtLeaveType.SelectedItem?.ToString();
            DateTime startDate = txtStartDate.SelectedDate ?? DateTime.Now;
            DateTime endDate = txtEndDate.SelectedDate ?? DateTime.Now;
            int hoursRequested = int.Parse(txtHoursRequested.Text);

            // Process the leave request

            if (string.IsNullOrEmpty(leaveType))
            {
                MessageBox.Show("Please select a leave type.");
                return;
            }
            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.");
                return;
            }
            if (hoursRequested <= 0)
            {
                MessageBox.Show("Please enter a valid number of hours requested.");
                return;
            }

            MessageBox.Show($"Leave request submitted:\nType: {leaveType}\nStart Date: {startDate.ToShortDateString()}\nEnd Date: {endDate.ToShortDateString()}\nHours Requested: {hoursRequested}");
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

        }

    }
}
