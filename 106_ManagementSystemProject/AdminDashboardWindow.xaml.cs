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
            Database.CreateDatabase();
            LoadEmployees();        // Load the employees from the database

        }

        // -------------------------
        // Employee Info methods
        // -------------------------

        // Buttons: Save, About, Delete, Update ------------------------------------------
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();    // Trim() deletes an extra space before or after

            // Let's check if all fields are full:
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter the employee's First Name.");
                return;
            }

            string lastName = txtLastName.Text.Trim();
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter the employee's Last Name.");
                return;
            }

            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter the employee's Email.");
                return;
            }

            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter the employee's Phone.");
                return;
            }

            string jobTitle = txtJobTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                MessageBox.Show("Please enter the employee's Job Title.");
                return;
            }

            string department = txtDepartment.Text.Trim();
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

            // Add the temporary employee instance to the database:
            Database.AddEmployee(employee);

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
            MessageBox.Show("Under Maintenance");                   // UNDER MAINTENANCE!!!
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

            Database.DeleteEmployee(selectedEmployee.Id);
            LoadEmployees();
        }
        // ------------------------------------------------------------------------------

        //  Load list after saving the employee info ------------------------------------
        private void LoadEmployees()
        {
            dgManageEmployee.ItemsSource = Database.GetEmployees(); // GetEmployees method is in the database class
        }
        // ------------------------------------------------------------------------------


        // -------------------------
        // Employee Info methods END
        // -------------------------


    } // Class end






}   // Namespace end

