using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDistribution.DAL;
using TechDistribution.BLL;
using TechDistribution.VALIDATION;
using System.Windows.Forms;


namespace TechDistribution.GUI
{
    public partial class EmployeeManagament : Form
    {

        public EmployeeManagament()
        {
            InitializeComponent();
            comboBoxStatus.SelectedIndex = 0;
            comboBoxJobTitle.SelectedIndex = 0;
            comboBoxSearchBy.SelectedIndex = 0;
        }

        private void clearFields()
        {
            textBoxSearchEmployeeID.Clear();
            textBoxSearchFirstName.Clear();
            textBoxSearchLastName.Clear();
            textBoxSearchEmail.Clear();
            textBoxSearchPhoneNumber.Clear();
            comboBoxSearchStatus.SelectedIndex = -1;
            comboBoxSearchJobTitle.SelectedIndex = -1;
        }

        private void SearchByID()
        {

            clearFields();

            string id = textBoxSearchBy.Text.Trim();

            if (!Validator.IsValidID(id))
            {
                MessageBox.Show("The ID you wrote is not valid, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int realId = Convert.ToInt32(id);

            if (!Employee.IsAExistingEmployee(realId))
            {
                MessageBox.Show("The ID you wrote is not found, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee emp = new Employee();

            emp = EmployeeDB.GetEmployeeByID(realId);

            listViewSearch.Items.Clear();
            ListViewItem row = new ListViewItem(emp.EmployeeId.ToString());
            row.SubItems.Add(emp.FirstName);
            row.SubItems.Add(emp.LastName);
            row.SubItems.Add(emp.Email);
            row.SubItems.Add(emp.PhoneNumber);
            row.SubItems.Add(emp.StatusDesc);
            row.SubItems.Add(emp.JobTitle);

            listViewSearch.Items.Add(row);

            textBoxSearchEmployeeID.Text = emp.EmployeeId.ToString();
            textBoxSearchFirstName.Text = emp.FirstName;
            textBoxSearchLastName.Text = emp.LastName;
            textBoxSearchEmail.Text = emp.Email;
            textBoxSearchPhoneNumber.Text = emp.PhoneNumber;

            int idx = comboBoxSearchStatus.Items.IndexOf(emp.StatusDesc);

            comboBoxSearchStatus.SelectedIndex = idx;

            idx = comboBoxJobTitle.Items.IndexOf(emp.JobTitle);

            comboBoxSearchJobTitle.SelectedIndex = idx;

            //comboBoxSearchStatus.SelectedText = emp.StatusDesc;
            //comboBoxSearchJobTitle.SelectedText = emp.JobTitle;

        }

        private void SearchByFirstName()
        {
            string text = textBoxSearchBy.Text;
            if (!Validator.IsValidText(text))
            {
                MessageBox.Show("The input you wrote is an incorrect format, try again");
                return;
            }

            List<Employee> employees = Employee.SearchByFirstName(text);

            if(employees.Count == 0)
            {
                MessageBox.Show("That First Name is not in our records");
                return;
            }

            clearFields();

            listViewSearch.Items.Clear();
            

            foreach (Employee emp in employees)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.Email);
                item.SubItems.Add(emp.PhoneNumber);
                item.SubItems.Add(emp.StatusDesc);
                item.SubItems.Add(emp.JobTitle);

                listViewSearch.Items.Add(item);
            }

        }

        private void SearchByLastName()
        {
            string text = textBoxSearchBy.Text;
            if (!Validator.IsValidText(text))
            {
                MessageBox.Show("The input you wrote is an incorrect format, try again");
                return;
            }

            List<Employee> employees = Employee.SearchByLastName(text);

            if (employees.Count == 0)
            {
                MessageBox.Show("That Last Name is not in our records");
                return;
            }

            clearFields();
            listViewSearch.Items.Clear();

            foreach (Employee emp in employees)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.Email);
                item.SubItems.Add(emp.PhoneNumber);
                item.SubItems.Add(emp.StatusDesc);
                item.SubItems.Add(emp.JobTitle);

                listViewSearch.Items.Add(item);
            }
        }

        private void SearchByEmail()
        {
            string text = textBoxSearchBy.Text;
            if (!Validator.IsValidEmail(text))
            {
                MessageBox.Show("The input you wrote is an incorrect format, try again");
                return;
            }

            List<Employee> employees = Employee.SearchByEmail(text);

            if (employees.Count == 0)
            {
                MessageBox.Show("That Email is not in our records");
                return;
            }

            clearFields();
            listViewSearch.Items.Clear();

            foreach (Employee emp in employees)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.Email);
                item.SubItems.Add(emp.PhoneNumber);
                item.SubItems.Add(emp.StatusDesc);
                item.SubItems.Add(emp.JobTitle);

                listViewSearch.Items.Add(item);
            }
        }

        private void SearchByPhoneNumber()
        {
            string text = textBoxSearchBy.Text;
            if (!Validator.IsValidPhoneNumber(text))
            {
                MessageBox.Show("The input you wrote is an incorrect format, try again");
                return;
            }

            List<Employee> employees = Employee.SearchByPhoneNumber(text);

            if (employees.Count == 0)
            {
                MessageBox.Show("That Phone Number is not in our records");
                return;
            }

            clearFields();
            listViewSearch.Items.Clear();

            foreach (Employee emp in employees)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.Email);
                item.SubItems.Add(emp.PhoneNumber);
                item.SubItems.Add(emp.StatusDesc);
                item.SubItems.Add(emp.JobTitle);

                listViewSearch.Items.Add(item);
            }
        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            List<Employee> employees = new List<Employee>();

            employees = Employee.GetEmployees();

            listViewAllEmployees.Items.Clear();

            foreach (Employee emp in employees)
            {
                ListViewItem row = new ListViewItem(emp.EmployeeId.ToString());
                row.SubItems.Add(emp.FirstName);
                row.SubItems.Add(emp.LastName);
                row.SubItems.Add(emp.Email);
                row.SubItems.Add(emp.PhoneNumber);
                row.SubItems.Add(emp.StatusDesc);
                row.SubItems.Add(emp.JobTitle);

                listViewAllEmployees.Items.Add(row);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string input = textBoxFirstName.Text.Trim();

            if (!Validator.IsValidText(input))
            {
                MessageBox.Show("The Firstname you wrote is not correct, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            input = textBoxLastName.Text.Trim();

            if (!Validator.IsValidText(input))
            {
                MessageBox.Show("The Lastname you wrote is not correct, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            input = textBoxEmail.Text.Trim();

            if (!Validator.IsValidEmail(input))
            {
                MessageBox.Show("The Email you wrote is not correct, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            input = textBoxPhoneNumber.Text.Trim();

            if (!Validator.IsValidPhoneNumber(input))
            {
                MessageBox.Show("The Phone number you wrote is not correct, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (comboBoxJobTitle.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select a Job title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee emp = new Employee();

            emp.FirstName = textBoxFirstName.Text.Trim();
            emp.LastName = textBoxLastName.Text.Trim();
            emp.Email = textBoxEmail.Text.Trim();
            emp.PhoneNumber = textBoxPhoneNumber.Text.Trim();
            emp.StatusId = statusPK(comboBoxStatus.SelectedIndex);
            emp.JobId = jobTitlePK(comboBoxJobTitle.SelectedIndex);

            if (!emp.AddEmployee(emp))
            {
                MessageBox.Show("Error at time to add the Employee");
                return;
            }

            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            textBoxPhoneNumber.Clear();
            textBoxPhoneNumber.Clear();
            comboBoxStatus.SelectedIndex = 0;
            comboBoxJobTitle.SelectedIndex = 0;

            textBoxFirstName.Focus();

            MessageBox.Show("The Employee was add successfully");

        }


        private int statusPK(int idx)
        {
            switch (idx)
            {
                case 0:
                    return 3;
                case 1:
                    return 4;
                case 2:
                    return 5;
                default:
                    return -1;
            }
        }

        private int jobTitlePK(int idx)
        {
            return idx + 1;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            int idx = comboBoxSearchBy.SelectedIndex;

            switch (idx)
            {
                case 0:     //Search By ID
                    SearchByID();
                    break;
                case 1:     //Search By FirstName
                    SearchByFirstName();
                    break;
                case 2:     //Search By LastName
                    SearchByLastName();
                    break;
                case 3:     // Search By Email
                    SearchByEmail();
                    break;
                case 4:     // Search By PhoneNumber
                    SearchByPhoneNumber();
                    break;
            }
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSearchBy.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string text = textBoxSearchEmployeeID.Text;
            if (String.IsNullOrEmpty(text))
            {
                MessageBox.Show("The Employee ID is empty, please, Search the ID before Update");
                return;
            }

            text = textBoxSearchFirstName.Text.Trim();

            if (!Validator.IsValidText(text))
            {
                MessageBox.Show("The Firstname you wrote is an invalid format, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchFirstName.Clear();
                textBoxSearchFirstName.Focus();
                return;
            }

            text = textBoxSearchLastName.Text.Trim();

            if(!Validator.IsValidText(text))
            {
                MessageBox.Show("The Last name you wrote is an invalid format, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchLastName.Clear();
                textBoxSearchLastName.Focus();
                return;
            }

            text = textBoxSearchEmail.Text.Trim();

            if (!Validator.IsValidEmail(text))
            {
                MessageBox.Show("The Email you wrote is an invalid format, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchEmail.Clear();
                textBoxSearchEmail.Focus();
                return;
            }

            text = textBoxSearchPhoneNumber.Text.Trim();

            if (!Validator.IsValidPhoneNumber(text))
            {
                MessageBox.Show("The Phone number you wrote is an invalid format, try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchPhoneNumber.Clear();
                textBoxSearchPhoneNumber.Focus();
                return;
            }

            Employee newEmp = new Employee();

            newEmp.FirstName = textBoxSearchFirstName.Text.Trim();
            newEmp.LastName = textBoxSearchLastName.Text.Trim();
            newEmp.Email = textBoxSearchEmail.Text.Trim();
            newEmp.PhoneNumber = textBoxSearchPhoneNumber.Text.Trim();

            int idx = comboBoxSearchStatus.SelectedIndex;

            newEmp.StatusId = statusPK(idx);

            idx = comboBoxSearchJobTitle.SelectedIndex;

            newEmp.JobId = jobTitlePK(idx);

            Employee.UpdateEmployee(newEmp);
            

            MessageBox.Show($"The employee {newEmp.FirstName} {newEmp.LastName} was updated succesfully", "Information", MessageBoxButtons.OK);

            clearFields();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(textBoxSearchEmployeeID.Text.Length == 0)
            {
                MessageBox.Show("Please, Search by ID the Employee you want to Delete");
                return;
            }

            DialogResult dr = MessageBox.Show($"Do you want to delete the Employee{textBoxSearchFirstName.Text} {textBoxSearchLastName.Text}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int id = Convert.ToInt32(textBoxSearchEmployeeID.Text);
                try
                {
                    Employee.DeleteEmployee(id);
                    MessageBox.Show("Success Delete", "Information");
                    clearFields();
                    listViewSearch.Items.Clear();
                }
                catch (Exception ep)
                {
                    MessageBox.Show("There were a problem at delete the employee" + ep.ToString());
                    return;
                }
                
            }


        }
    }
}
