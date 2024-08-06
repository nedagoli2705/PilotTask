using PilotTask_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using PilotTask_MVC.Repositories.Interfaces;

namespace PilotTask_MVC.DataAccess
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly string _connectionString;

        public ProfileRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertProfile(Profile profile)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", profile.FirstName);
                cmd.Parameters.AddWithValue("@LastName", profile.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", profile.DateOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", profile.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailId", profile.EmailId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProfile(Profile profile) 
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfileId", profile.ProfileId);
                cmd.Parameters.AddWithValue("@FirstName", profile.FirstName);
                cmd.Parameters.AddWithValue("@LastName", profile.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", profile.DateOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", profile.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailId", profile.EmailId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProfile(int profileId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfileId", profileId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Profile> GetProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetProfiles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        profiles.Add(new Profile
                        {
                            ProfileId = Convert.ToInt32(reader["ProfileId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            EmailId = reader["EmailId"].ToString()
                        });
                    }
                }
            }

            return profiles;
        }
    }
}