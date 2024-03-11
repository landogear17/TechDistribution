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
        private int jobId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public int JobId { get => jobId; set => jobId = value; }

        public Employee() { }

        public List<Employee> GetEmployees()
        {
            return EmployeeDB.GetAllRecords();
        }
        public void CreateAccountEmployee(Employee employee)
        {
            EmployeeDB.SaveEmployee(employee);
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

        public bool IsAExistingEmployee(int employeeId)
        {
            bool existing = EmployeeDB.IsAnExistingEmployee(employeeId);
            return existing;
        }


    }
}
