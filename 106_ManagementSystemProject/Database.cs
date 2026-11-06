using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

// Here we created a Class from where will be created a database instance
// where employee information will be saved

namespace _106_ManagementSystemProject
{
    public class Database
    {
        //==============================================================================
        // Employee METHODS
        //==============================================================================
        // Employee METHOD 01: will be called in the AdminDashboardWindown.cs
        public static void CreateDatabase()
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))   // this is the database file where employee info will be saved
            {
                connection.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        Email TEXT,
                        Phone TEXT,
                        JobTitle TEXT,
                        Department TEXT
                    );";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }
        // Employee METHOD 02: called in the Save_Click method in the AdminDashboardWindown.cs
        public static void AddEmployee(Employee employee)
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();

                string sql = @"INSERT INTO Employees (FirstName, LastName, Email, Phone, JobTitle, Department)
                               VALUES (@FirstName, @LastName, @Email, @Phone, @JobTitle, @Department)";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@Department", employee.Department);

                    command.ExecuteNonQuery();
                }


            }
        }
        // Employee METHOD 03: called in the LoadEmployees() method  in the AdminDashboardWindown.cs
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();
                string sql = "SELECT * FROM Employees";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();

                            employee.Id = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = reader.GetString(2);
                            employee.Email = reader.GetString(3);
                            employee.Phone = reader.GetString(4);
                            employee.JobTitle = reader.GetString(5);
                            employee.Department = reader.GetString(6);

                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }
        // EmployeeMETHOD 04: called in the Employee Info
        public static void DeleteEmployee(int id)
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();
                string sql = "DELETE FROM Employees WHERE Id = @Id;";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        // Employee METHOD 05: called in the Employee Info
        public static void UpdateEmployee(Employee employee)
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();
                string sql = @"UPDATE Employees
                               SET FirstName = @FirstName,
                                   LastName = @LastName,
                                   Email = @Email,
                                   Phone = @Phone,
                                   JobTitle = @JobTitle,
                                   Department = @Department
                                   WHERE Id = @Id;";
                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@Department", employee.Department);

                    command.ExecuteNonQuery();
                }
            }

        }
        // ===============================================================================

        // ❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️❤️
        //==============================================================================
        // Leave Requests METHODS
        //==============================================================================


    }
}
