using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDistribution.DAL;
using TechDistribution.BLL;


namespace TechDistribution.BLL
{
    public class User
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string password;
        private string dateCreated;
        private string dateModified;
        private int statusId;
        private string statusDesc;
        private int employeeId;
        private int jobId;
        private string jobTitle;

        public int UserId { get => userId; set => userId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public string DateCreated { get => dateCreated; set => dateCreated = value; }
        public string DateModified { get => dateModified; set => dateModified = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public string StatusDesc { get => statusDesc; set => statusDesc = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public int JobId { get => jobId; set => jobId = value; }

        public User() { }

        public User(int userId, string firstName, string lastName, string password, string dateCreated, string dateModified, int statusId, string statusDesc, int employeeId, int jobId, string jobTitle)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.dateCreated = dateCreated;
            this.dateModified = dateModified;
            this.statusId = statusId;
            this.statusDesc = statusDesc;
            this.employeeId = employeeId;
            this.JobId = jobId;
            this.jobTitle = jobTitle;
        }

        public static bool IsAExistingEmployee(int employeeId)
        {
            bool existing = EmployeeDB.IsAnExistingEmployee(employeeId);
            return existing;
        }

        public User SearchUser(int userId)
        {
            return UserDB.SearchUser(userId);
        }

        public static List<User> GetUsers()
        {
            return UserDB.GetAllUsers();
        }
        public void CreateUseAccount(User user)
        {
            UserDB.SaveUser(user);
        }

        public static void ModifyUser(User user)
        {
            UserDB.modifyEmployee(user);
        }
        public static void DeleteUser(int userId)
        {
            UserDB.DeleteEmployee(userId);
        }

        public static void UpdateUser(User user)
        {
            UserDB.UpdateUser(user);
        }

    }
}
