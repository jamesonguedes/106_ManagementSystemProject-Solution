using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _106_ManagementSystemProject
{

    public class LeaveDatabase
    {
        //==============================================================================
        // LeaveRequest METHODS
        //==============================================================================

        public static void CreateDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=leaveRequests.db"))   // this is the database file where leave requests will be saved
            {
                connection.Open();

                string sql = @"
                    CREATE TABLE IF NOT EXISTS LeaveRequests (
                        RequestId INTEGER Primary KEY AUTOINCREMENT,
                        Id INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        LeaveType TEXT NOT NULL,
                        StartDate TEXT,
                        EndDate TEXT,
                        HoursRequested INTEGER,
                        Status TEXT
                    );";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                    command.ExecuteNonQuery();
            }

        }

        public static void RequestLeave(LeaveRequest leaveRequest)
        {
            CreateDatabase();

            using (SqliteConnection connection =
                new SqliteConnection("Data Source=leaveRequests.db"))
            {
                connection.Open();

                string sql = @"INSERT INTO LeaveRequests (Id, Name, LeaveType, StartDate, EndDate, HoursRequested, Status)
                               VALUES (@Id, @Name, @LeaveType, @StartDate, @EndDate, @HoursRequested, @Status)";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", leaveRequest.Id);
                    command.Parameters.AddWithValue("@Name", leaveRequest.Name);
                    command.Parameters.AddWithValue("@LeaveType", leaveRequest.LeaveType);
                    command.Parameters.AddWithValue("@StartDate", leaveRequest.StartDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@EndDate", leaveRequest.EndDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@HoursRequested", leaveRequest.HoursRequested);
                    command.Parameters.AddWithValue("@Status", leaveRequest.Status);

                    command.ExecuteNonQuery();
                }

            }
        }

        // Used to load only the current employee's requests.
        // Will be displayed in Emploee Dashboard who's logged in at the moment.
        // Find in the EmployeeDashboardWindow.cs
        public static List<LeaveRequest> GetMyRequests(int employeeId)
        {
            CreateDatabase();
            List<LeaveRequest> myLeaveRequests = new List<LeaveRequest>();
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=leaveRequests.db"))
            {
                connection.Open();
                string sql = @"SELECT RequestId, Id, LeaveType, StartDate, EndDate, Hoursrequested, Status
                             FROM LeaveRequests
                             WHERE Id = @Id;";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", employeeId);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LeaveRequest leaveRequest = new LeaveRequest();

                            leaveRequest.RequestId = reader.GetInt32(0);
                            leaveRequest.Id = reader.GetInt32(1);
                            leaveRequest.LeaveType = reader.GetString(2);
                            leaveRequest.StartDate = DateTime.Parse(reader.GetString(3));
                            leaveRequest.EndDate = DateTime.Parse(reader.GetString(4));
                            leaveRequest.HoursRequested = reader.GetInt32(5);
                            leaveRequest.Status = reader.GetString(6);

                            myLeaveRequests.Add(leaveRequest);

                        }
                    }
                }
            }

            return myLeaveRequests;
        }

        // Used to load all the employee's requests.
        // Will be displayed in Admin Dashboard for approval.
        // Find in the AdminDashboardWindow.cs
        public static List<LeaveRequest> GetAllRequests()
        {
            CreateDatabase();

            List<LeaveRequest> allLeaveRequests = new List<LeaveRequest>();
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=leaveRequests.db"))
            {
                connection.Open();
                string sql = "SELECT * FROM leaveRequests";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LeaveRequest leaveRequest = new LeaveRequest();

                            leaveRequest.RequestId = reader.GetInt32(0);
                            leaveRequest.Id = reader.GetInt32(1);
                            leaveRequest.Name = reader.GetString(2);
                            leaveRequest.LeaveType = reader.GetString(3);
                            leaveRequest.StartDate = DateTime.Parse(reader.GetString(4));
                            leaveRequest.EndDate = DateTime.Parse(reader.GetString(5));
                            leaveRequest.HoursRequested = reader.GetInt32(6);
                            leaveRequest.Status = reader.GetString(7);

                            allLeaveRequests.Add(leaveRequest);

                        }
                    }
                }
            }

            return allLeaveRequests;
        }

        public static void UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=leaveRequests.db"))
            {
                connection.Open();

                string sql = @"UPDATE LeaveRequests
                               SET LeaveType = @LeaveType,
                                   StartDate = @StartDate,
                                   EndDate = @EndDate,
                                   HoursRequested = @HoursRequested,
                                   Status = @Status
                                   WHERE RequestId = @RequestId
                                   AND Id = @Id;";
                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@RequestId", leaveRequest.RequestId);
                    command.Parameters.AddWithValue("@Id", leaveRequest.Id);
                    command.Parameters.AddWithValue("@Name", leaveRequest.Name);
                    command.Parameters.AddWithValue("@LeaveType", leaveRequest.LeaveType);
                    command.Parameters.AddWithValue("@StartDate", leaveRequest.StartDate);
                    command.Parameters.AddWithValue("@EndDate", leaveRequest.EndDate);
                    command.Parameters.AddWithValue("@HoursRequested", leaveRequest.HoursRequested);
                    command.Parameters.AddWithValue("@Status", leaveRequest.Status);

                    int rowUpdated = command.ExecuteNonQuery();

                    if (rowUpdated == 0)
                    {
                        MessageBox.Show("No Request Found ");
                    }

                }
            }

        }

    }
}
