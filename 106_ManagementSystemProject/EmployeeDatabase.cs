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
    public class EmployeeDatabase
    {
        //==============================================================================
        // Employee METHODS
        //==============================================================================
        public static void CreateDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=employees.db"))   // this is the database file where employee info will be saved
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
                        Department TEXT,
                        Password TEXT
                    );";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                    command.ExecuteNonQuery();
            }
        }
        public static void AddEmployee(Employee employee)
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();

                string sql = @"INSERT INTO Employees (FirstName, LastName, Email, Phone, JobTitle, Department, Password)
                               VALUES (@FirstName, @LastName, @Email, @Phone, @JobTitle, @Department, @Password)";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Password", employee.Password);

                    command.ExecuteNonQuery();
                }

            }
        }
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
                            employee.Password = reader.GetString(7);

                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }
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

        public static bool Login(string email, string password)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();
                string sql = "SELECT * FROM Employees WHERE Email = @Email AND Password = @Password;";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Login successful
                            Console.WriteLine("Login successful!");
                            return true;
                        }
                        else
                        {
                            // Login failed
                            Console.WriteLine("Invalid email or password.");
                            return false;
                        }
                    }
                }
            }
        }

        public static Employee GetEmployeeByEmail(string email)
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=employees.db"))
            {
                connection.Open();
                string sql = "SELECT * FROM Employees WHERE Email = @Email;";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Employee employee = new Employee();

                            employee.Id = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.LastName = reader.GetString(2);
                            employee.Email = reader.GetString(3);
                            employee.Phone = reader.GetString(4);
                            employee.JobTitle = reader.GetString(5);
                            employee.Department = reader.GetString(6);
                            employee.Password = reader.GetString(7);

                            return employee;
                        }
                    }
                }
            }
            return null;
        }
    }
}