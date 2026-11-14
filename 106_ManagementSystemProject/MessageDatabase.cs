using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _106_ManagementSystemProject
{
    internal class MessageDatabase
    {
        //==============================================================================
        // Messages METHODS
        //==============================================================================

        public static void CreateDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=requestMessages.db"))
            {
                connection.Open();

                string sql = @"
                        CREATE TABLE IF NOT EXISTS RequestMessages (
                        MessageId INTEGER Primary KEY AUTOINCREMENT,
                        Id INTEGER NOT NULL,
                        Name TEXT NOT NULL,
                        MessageType TEXT NOT NUll,
                        Subject TEXT,
                        Description TEXT
                        );";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                    command.ExecuteNonQuery();
            }
        }

        public static void RequestMessage(MessageRequest messageRequest)
        {
            CreateDatabase();

            using (SqliteConnection connection =
                new SqliteConnection("Data Source=requestMessages.db"))
            {

                connection.Open();

                string sql = @"INSERT INTO RequestMessages (Id, Name, MessageType, Subject, Description)
                               VALUES (@Id, @Name, @MessageType, @Subject, @Description)";

                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", messageRequest.Id);
                    command.Parameters.AddWithValue("@Name", messageRequest.Name);
                    command.Parameters.AddWithValue("@MessageType", messageRequest.MessageType);
                    command.Parameters.AddWithValue("@Subject", messageRequest.Subject);
                    command.Parameters.AddWithValue("@Description", messageRequest.Description);

                    command.ExecuteNonQuery();
                }

            }
        }
    }
}