using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PilotTask_MVC.DataAccess
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertTask(Task task)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("InsertTask", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProfileId", task.ProfileId);
                command.Parameters.AddWithValue("@TaskName", task.TaskName);
                command.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                command.Parameters.AddWithValue("@StartTime", task.StartTime);
                command.Parameters.AddWithValue("@Status", task.Status);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTask(Task task)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateTask", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@ProfileId", task.ProfileId);
                command.Parameters.AddWithValue("@TaskName", task.TaskName);
                command.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                command.Parameters.AddWithValue("@StartTime", task.StartTime);
                command.Parameters.AddWithValue("@Status", task.Status);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int taskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteTask", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", taskId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Task GetTaskById(int taskId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetTaskByTaskId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TaskId", taskId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Task
                        {
                            Id = (int)reader["Id"],
                            ProfileId = (int)reader["ProfileId"],
                            TaskName = (string)reader["TaskName"],
                            TaskDescription = (string)reader["TaskDescription"],
                            StartTime = (DateTime)reader["StartTime"],
                            Status = (int)reader["Status"],
                            Profile = new Profile
                            {
                                ProfileId = (int)reader["ProfileId"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"]
                            }
                        };
                    }
                }
            }
            return null;
        }

        public List<Task> GetTasks()
        {
            var tasks = new List<Task>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Id = (int)reader["Id"],
                            ProfileId = (int)reader["ProfileId"],
                            TaskName = (string)reader["TaskName"],
                            TaskDescription = (string)reader["TaskDescription"],
                            StartTime = (DateTime)reader["StartTime"],
                            Status = (int)reader["Status"],
                            Profile = new Profile
                            {
                                ProfileId = (int)reader["ProfileId"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"]
                            }
                        });
                    }
                }
            }
            return tasks;
        }

        public List<Task> GetTasksByProfileId(int profileId)
        {
            var tasks = new List<Task>();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetTasksByProfileId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProfileId", profileId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            Id = (int)reader["Id"],
                            ProfileId = (int)reader["ProfileId"],
                            TaskName = (string)reader["TaskName"],
                            TaskDescription = (string)reader["TaskDescription"],
                            StartTime = (DateTime)reader["StartTime"],
                            Status = (int)reader["Status"]
                        });
                    }
                }
            }
            return tasks;
        }
    }
}