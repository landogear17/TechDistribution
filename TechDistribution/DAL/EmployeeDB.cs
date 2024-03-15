using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDistribution.BLL;

using TechDistribution.DAL;

namespace TechDistribution.DAL
{
    public class EmployeeDB
    {
        /* Trying*/

        public static List<Employee> GetEmployeesComplete()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();

            SqlCommand cmd = new SqlCommand("SELECT EmployeeId, FirstName, LastName, Email, PhoneNumber,e.StatusId, StatusDesc,e.JobId, JobTitle\r\nFROM Employees e, Status s, Jobs j\r\nWHERE e.StatusId = s.StatusId AND\r\ne.JobId = j.JobId;", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Employee emp;

            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.StatusId = Convert.ToInt32(reader["StatusId"]);
                emp.StatusDesc = reader["StatusDesc"].ToString();
                emp.JobId = Convert.ToInt32(reader["JobId"]);
                emp.JobTitle = reader["JobTitle"].ToString();
                listE.Add(emp);
            }
            conn.Close();
            return listE;
        }

        public static Employee GetEmployeeByID(int id)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT EmployeeId, FirstName, LastName, Email, PhoneNumber, StatusDesc, JobTitle FROM Employees e, Status s, Jobs j " +
                                        "WHERE EmployeeId = @EmployeeId AND e.StatusId = s.StatusId AND e.JobId = j.JobId;";
                cmdSearch.Parameters.AddWithValue("@EmployeeId", id);
                SqlDataReader reader = cmdSearch.ExecuteReader();

                reader.Read();
                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.PhoneNumber = reader["PhoneNumber"].ToString();
                emp.StatusDesc = reader["StatusDesc"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();

                return emp;
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





        public static List<Employee> GetAllRecords()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();

            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.Email = reader["Email"].ToString();

                listE.Add(employee);
            }
            conn.Close();
            return listE;

        }

        public static Employee SearchEmployee(int employeeId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT * FROM Employees " +
                                        "WHERE EmployeeId=@EmployeeId";
                cmdSearch.Parameters.AddWithValue("@EmployeeId", employeeId);
                SqlDataReader reader = cmdSearch.ExecuteReader();

                reader.Read();
                Employee employee = new Employee();
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.Email = reader["Email"].ToString();

                return employee;
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

        public static void SaveEmployee(Employee employee)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;
            cmdInsert.CommandText = "INSERT INTO Employees (FirstName,LastName,Email)" +
                                     "VALUES(@FirstName,@LastName,@Email)";


            cmdInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", employee.LastName);
            cmdInsert.Parameters.AddWithValue("@Email", employee.Email);



            //write the sequence statement (line to execute)
            cmdInsert.ExecuteNonQuery();
            conn.Close();

        }

        public static bool IsAnExistingEmployee(int employeeId)
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdFind = new SqlCommand("SELECT * FROM Employees WHERE EmployeeId = @EmployeeId", conn);
            cmdFind.Parameters.AddWithValue("@EmployeeId", employeeId);

            SqlDataReader reader = cmdFind.ExecuteReader(); //applied to select statement

            Employee student = new Employee();


            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

            conn.Close();
        }

        public static void modifyEmployee(Employee employeeUpdated)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Employees " +
                    "SET FirstName=@FirstName, " +
                         "LastName=@LastName, " +
                         "Email=@Email " +
                         "WHERE EmployeeId = @EmployeeId ";
                cmdUpdate.Parameters.AddWithValue("@EmployeeId", employeeUpdated.EmployeeId);
                cmdUpdate.Parameters.AddWithValue("@FirstName", employeeUpdated.FirstName);
                cmdUpdate.Parameters.AddWithValue("@LastName", employeeUpdated.LastName);
                cmdUpdate.Parameters.AddWithValue("@Email", employeeUpdated.Email);
                cmdUpdate.ExecuteNonQuery();

            }
        }

        public static void DeleteEmployee(int employeeId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE Employees " +
                                        "WHERE EmployeeId = @EmployeeId";
                cmdDelete.Parameters.AddWithValue("@EmployeeId", employeeId);
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

