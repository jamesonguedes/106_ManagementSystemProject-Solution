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

    public partial class AdminDashboardWindow : Window
    {
        public AdminDashboardWindow()
        {
            InitializeComponent();  // First start the applicaton
            EmployeeDatabase.CreateDatabase();
            LoadEmployees();        // Load the employees from the database

        }

        // -------------------------
        // Employee Info methods
        // -------------------------

        // Buttons: Save, About, Delete, Update ------------------------------------------

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Trim() deletes an extra space before or after
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim(); 
            string jobTitle = txtJobTitle.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string password = "Employee123";    // DEFAULT PASSWORD

            // Let's check if all fields are full:
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter the employee's First Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter the employee's Last Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter the employee's Email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter the employee's Phone.");
                return;
            }

            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                MessageBox.Show("Please enter the employee's Job Title.");
                return;
            }

            if (string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Please enter the employee's Department.");
                return;
            }



            // Create a temporary employee instance:
            Employee employee = new Employee();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.Phone = phone;
            employee.JobTitle = jobTitle;
            employee.Department = department;
            employee.Password = password;

            // Add the temporary employee instance to the database:
            EmployeeDatabase.AddEmployee(employee);

            // Displays the list of emlployees in the DataGrid:
            LoadEmployees();

            // Message to be displayed when new employee is added:
            MessageBox.Show("Name: " + employee.FirstName + " " + employee.LastName +
                "\nSaved successfully!");

            // Lets make sure all the fields are clean :)
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtJobTitle.Clear();
            txtDepartment.Clear();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // Checks if a row is selected
            Employee selectedEmployee = dgManageEmployee.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            // Trim() deletes an extra space before or after
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
            string department = txtDepartment.Text.Trim();

            // Let's check if all fields are full:
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter the employee's First Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter the employee's Last Name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter the employee's Email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter the employee's Phone.");
                return;
            }

            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                MessageBox.Show("Please enter the employee's Job Title.");
                return;
            }

            if (string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Please enter the employee's Department.");
                return;
            }

            // Create a temporary employee instance:
            Employee employee = new Employee();
            employee.Id = selectedEmployee.Id; // Make sure replaces the one selected
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.Phone = phone;
            employee.JobTitle = jobTitle;
            employee.Department = department;

            // Add the temporary employee instance to the database:
            EmployeeDatabase.UpdateEmployee(employee);

            // Displays the list of emlployees in the DataGrid:
            LoadEmployees();

            // Message to be displayed when new employee is added:
            MessageBox.Show("Employee Id " + employee.Id + " has been updated successfully!");

            // Lets make sure all the fields are clean :)
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtJobTitle.Clear();
            txtDepartment.Clear();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            Employee selectedEmployee = dgManageEmployee.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }
            MessageBoxResult answer = MessageBox.Show($"Are you sure you want to delete {selectedEmployee.FirstName} {selectedEmployee.LastName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer != MessageBoxResult.Yes)
            {
                return; // User chose not to delete
            }

            EmployeeDatabase.DeleteEmployee(selectedEmployee.Id);
            LoadEmployees();
        }
        // ------------------------------------------------------------------------------

        //  Load list after saving the employee info ------------------------------------
        private void LoadEmployees()
        {
            dgManageEmployee.ItemsSource = EmployeeDatabase.GetEmployees(); // GetEmployees method is in the database class
        }

        // ------------------------------------------------------------------------------

        //  Fiils up fields with selected row -------------------------------------------
        private void dgManageEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = dgManageEmployee.SelectedItem as Employee;

            if (selectedEmployee == null)
            {
                return;
            }

            txtFirstName.Text = selectedEmployee.FirstName;
            txtLastName.Text = selectedEmployee.LastName;
            txtEmail.Text = selectedEmployee.Email;
            txtPhone.Text = selectedEmployee.Phone;
            txtJobTitle.Text = selectedEmployee.JobTitle;
            txtDepartment.Text = selectedEmployee.Department;

        }
        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (dgLeaveRequest.SelectedItem is Employee selectedEmployee)
            {
                // Perform the approval action for the selected employee
                MessageBox.Show($"Employee {selectedEmployee.FirstName} {selectedEmployee.LastName} has been approved.");
            }
            else
            {
                MessageBox.Show("Please select an employee to approve.");
            }
        }
        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            if (dgLeaveRequest.SelectedItem is Employee selectedEmployee)
            {
                // Perform the rejection action for the selected employee
                MessageBox.Show($"Employee {selectedEmployee.FirstName} {selectedEmployee.LastName} has been rejected.");
            }
            else
            {
                MessageBox.Show("Please select an employee to reject.");
            }
        }
    }
     // ------------------------------------------------------------------------------

        // -------------------------
        // Employee Info methods END
        // -------------------------
    // Class end
}   // Namespace end

