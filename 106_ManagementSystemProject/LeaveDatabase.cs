using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    command.Parameters.AddWithValue("@StartDate", leaveRequest.StartDate);
                    command.Parameters.AddWithValue("@EndDate", leaveRequest.EndDate);
                    command.Parameters.AddWithValue("@HoursRequested", leaveRequest.HoursRequested);
                    command.Parameters.AddWithValue("@Status", leaveRequest.Status);

                    command.ExecuteNonQuery();
                }

            }
        }

        public static List<LeaveRequest> GetMyRequests(int employeeId)
        {
            CreateDatabase();
            List<LeaveRequest> myLeaveRequests = new List<LeaveRequest>();
            using (SqliteConnection connection =
                new SqliteConnection("Data Source=leaveRequests.db"))
            {
                connection.Open();
                string sql = @"SELECT LeaveType, StartDate, EndDate, Hoursrequested, Status
                             FROM LeaveRequests
                             WHERE Id = Id;";

                using (SqliteCommand command =
                    new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", employeeId);

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LeaveRequest leaveRequest = new LeaveRequest();

                            leaveRequest.LeaveType = reader.GetString(0);
                            leaveRequest.StartDate = DateTime.Parse(reader.GetString(1));
                            leaveRequest.EndDate = DateTime.Parse(reader.GetString(2));
                            leaveRequest.HoursRequested = reader.GetInt32(3);
                            leaveRequest.Status = reader.GetString(4);

                            myLeaveRequests.Add(leaveRequest);

                        }
                    }
                }
            }

            return myLeaveRequests;
        }

    }
}
