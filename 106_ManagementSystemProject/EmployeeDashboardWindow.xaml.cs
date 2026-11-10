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
        private int employeeId;
        public EmployeeDashboardWindow(Employee employee)
        {
            InitializeComponent();

            employeeId = employee.Id;

            txtEmployeeId.Text = "Employee ID: " + employee.Id.ToString();
            txtEmployeeName.Text = employee.FirstName + " " + employee.LastName;
            txtEmployeeRole.Text = "Job Title: " + employee.JobTitle;
            txtEmployeeEmail.Text = "Email: " + employee.Email;
            txtEmployeePhone.Text = "Phone: " + employee.Phone;
            txtEmployeeDepartment.Text = "Department: " + employee.Department;

            LoadMyLeaveRequests();
        }
        // ================================================================
        // Request Leave Method
        // ================================================================
        private void RequestLeave_Click(object sender, RoutedEventArgs e)
        {
            int id = employeeId;
            string Name = txtEmployeeName.Text.Trim();
            string leaveType = (txtLeaveType.SelectedItem as ComboBoxItem)?.Content?.ToString();
            DateTime startDate = txtStartDate.SelectedDate ?? DateTime.Now;
            DateTime endDate = txtEndDate.SelectedDate ?? DateTime.Now;
            int hoursRequested = int.Parse(txtHoursRequested.Text);
            string status = "PENDING";

            // Let's check if all fields are full:
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

            // Create a temporary LeaveRequest instance:
            LeaveRequest leaveRequest = new LeaveRequest();

            leaveRequest.Id = id;
            leaveRequest.Name = Name;
            leaveRequest.LeaveType = leaveType;
            leaveRequest.StartDate = startDate;
            leaveRequest.EndDate = endDate;
            leaveRequest.HoursRequested = hoursRequested;
            leaveRequest.Status = status;

            // Adds the temporary LeaveRequest instance to the database:
            LeaveDatabase.RequestLeave(leaveRequest);

            // Displays the list of requests in the DataGrid:
            LoadMyLeaveRequests();


       
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



        private void LoadMyLeaveRequests()
        {
            dgLeaveRequests.ItemsSource =
                LeaveDatabase.GetMyRequests(employeeId); // Get my reques in the leave database
        }

        private void SubmitGrievance_Click(object sender, RoutedEventArgs e)
        {
            string subject = txtSubject.Text.Trim();
            string DescriptionText = txtDescription.Text.Trim();
            if (string.IsNullOrEmpty(subject))
            {
                MessageBox.Show("Please enter a subject for the grievance.");
                return;
            }
            if (string.IsNullOrEmpty(DescriptionText))
            {
                MessageBox.Show("Please enter a description for the grievance.");
                return;
            }

            MessageBox.Show("Grievance submitted successfully.");
        }
    }
}
