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

            Employee employee = new Employee();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.Phone = phone;
            employee.JobTitle = jobTitle;
            employee.Department = department;

            Database.AddEmployee(employee); // AddEmployee method is in the database class

            MessageBox.Show("Emplouee ID: " + employee.Id + 
                "\nName: " + employee.FirstName + " " + employee.LastName +
                "\nSaved successfully!");

            // Lets make sure all the fields are clean :)
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtJobTitle.Clear();
            txtDepartment.Clear();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Maintenance");                   // UNDER MAINTENANCE!!!
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Maintenance");                   // UNDER MAINTENANCE!!!
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under Maintenance");                   // UNDER MAINTENANCE!!!
        }
        // ------------------------------------------------------------------------------

        //  Load list after saving the employee info ------------------------------------
        private void LoadEmployees()
        {
            EmployeesListBox.ItemsSource = Database.GetEmployees(); // GetEmployees method is in the database class
        }
        // ------------------------------------------------------------------------------


        // -------------------------
        // Employee Info methods END
        // -------------------------


    } // Class end






}   // Namespace end

