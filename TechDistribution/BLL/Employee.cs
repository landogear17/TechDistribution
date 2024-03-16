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

        public static void ModifyEmployee(Employee employee)
        {
            EmployeeDB.modifyEmployee(employee);
        }
        public static void DeleteEmployee(int empId)
        {
            EmployeeDB.DeleteEmployee(empId);
        }

        public static bool IsAExistingEmployee(int employeeId)
        {
            bool existing = EmployeeDB.IsAnExistingEmployee(employeeId);
            return existing;
        }

        public static List<Employee> SearchByFirstName(string FirstName)
        {
            List<Employee> employees = EmployeeDB.GetEmployeesComplete();
            var empFiltered = employees.Where(x => x.firstName.ToLower() == FirstName.ToLower()).ToList();

            return empFiltered;
        }

        public static List<Employee> SearchByLastName(string LastName)
        {
            List<Employee> empFiltered = EmployeeDB.GetEmployeesComplete().Where(x => x.lastName.ToLower() == LastName.ToLower()).ToList();

            return empFiltered;

        }

        public static List<Employee> SearchByEmail(string Email)
        {
            var empFiltered = EmployeeDB.GetEmployeesComplete().Where(x => x.email == Email).ToList();
            return empFiltered;
        }

        public static List<Employee> SearchByPhoneNumber(string PhoneNumber)
        {
            var empFiltered = EmployeeDB.GetEmployeesComplete().Where(x => x.phoneNumber == PhoneNumber).ToList();

            return empFiltered;
        }

        public static void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateEmployee(emp);
        }


    }
}
