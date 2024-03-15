using TechDistribution.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechDistribution.BLL
{
    public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private int statusId;
        private string statusDesc;
        private int jobId;
        private string jobTitle;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public string StatusDesc { get => statusDesc; set => statusDesc = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public Employee() { }

        public static List<Employee> GetEmployees()
        {
            return EmployeeDB.GetEmployeesComplete();
        }
        public void CreateAccountEmployee(Employee employee)
        {
            EmployeeDB.SaveEmployee(employee);
        }

        public bool AddEmployee(Employee employee)
        {
            return EmployeeDB.AddEmployee(employee);
        }
        public Employee SearchEmployee(int employeeId)
        {
            return EmployeeDB.SearchEmployee(employeeId);
        }

        public void ModifyEmployee(Employee employee)
        {
            EmployeeDB.modifyEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            EmployeeDB.DeleteEmployee(employee.employeeId);
        }

        public static bool IsAExistingEmployee(int employeeId)
        {
            bool existing = EmployeeDB.IsAnExistingEmployee(employeeId);
            return existing;
        }

        public static List<Employee> SearchByFirstName(string FirstName)
        {
            List<Employee> employees = EmployeeDB.GetEmployeesComplete();
            var empFiltered = employees.Where(x => x.firstName == FirstName).ToList();

            return empFiltered;
        }


    }
}
