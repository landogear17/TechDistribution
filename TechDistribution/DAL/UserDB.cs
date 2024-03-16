using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechDistribution.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TechDistribution.DAL
{
    public class UserDB
    {
        private static void RollBack(SqlTransaction transaction)
        {
            transaction.Rollback();
        }


        public static bool createUserAccount(User user)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO UserAccounts(Password,StatusId, EmployeeId) " +
                                  "VALUES (@Password, @StatusId, @EmployeeId);";

                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@StatusId", user.StatusId);
                cmd.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);


                cmd.ExecuteNonQuery();
            }
            catch (Exception en)
            {
                MessageBox.Show(en.ToString());
                return false;
            }

            conn.Close();
            return true;
        }


        public static List<User> GetAllUsers()
        {
            List<User> listU = new List<User>();
            SqlConnection conn = UtilityDB.GetDBConnection();

            SqlCommand cmd = new SqlCommand("SELECT UA.UserId, E.FirstName, E.LastName, UA.DateCreated, UA.DateModified, UA.StatusId, S.StatusDescription, E.JobId, J.JobTitle " +
                                "FROM UserAccount UA " +
                                "INNER JOIN Employees E ON UA.EmployeeId = E.EmployeeId " +
                                "INNER JOIN Status S ON UA.StatusId = S.StatusId " +
                                "INNER JOIN Jobs J ON E.JobId = J.JobId;", conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateCreated = reader["DateCreated"].ToString(),
                        DateModified = reader["DateModified"].ToString(),
                        StatusId = Convert.ToInt32(reader["StatusId"]),
                        StatusDesc = reader["StatusDescription"].ToString(),
                        JobId = Convert.ToInt32(reader["JobId"]),
                        JobTitle = reader["JobTitle"].ToString()
                    };

                    listU.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listU;
        }


        public static User SearchUser(int userId)
        {

            SqlConnection conn = UtilityDB.GetDBConnection();

            SqlCommand cmd = new SqlCommand("SELECT UA.UserId, E.FirstName, E.LastName, UA.DateCreated, UA.DateModified, UA.StatusId, S.StatusDescription, E.JobId, J.JobTitle " +
                                 "FROM UserAccount UA " +
                                 "INNER JOIN Employees E ON UA.EmployeeId = E.EmployeeId " +
                                 "INNER JOIN Status S ON UA.StatusId = S.StatusId " +
                                 "INNER JOIN Jobs J ON E.JobId = J.JobId " +
                                 "WHERE UA.UserId = @UserId;", conn);

            cmd.Parameters.AddWithValue("@UserId", userId); // Add UserId parameter

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateCreated = reader["DateCreated"].ToString(),
                        DateModified = reader["DateModified"].ToString(),
                        StatusId = Convert.ToInt32(reader["StatusId"]),
                        StatusDesc = reader["StatusDescription"].ToString(),
                        JobId = Convert.ToInt32(reader["JobId"]),
                        JobTitle = reader["JobTitle"].ToString()
                    };

                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;

        }

        public static void UpdateUser(User user)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "UPDATE UserAccounts " +
                                  "SET Password = @Password, " +
                                  "WHERE UserId = @UserId;";

                cmd.Parameters.AddWithValue("@Password", user.Password);
                

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return;
                }
            }
        }



        public static void DeleteUser(int userId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE UserAccounts " +
                                        "WHERE UserId = @UserId";
                cmdDelete.Parameters.AddWithValue("@UserId", userId);
                cmdDelete.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                conn.Close();
            }
        }
    }
}

