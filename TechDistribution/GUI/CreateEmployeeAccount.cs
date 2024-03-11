using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechDistribution.DAL;
using TechDistribution.BLL;

namespace TechDistribution.GUI
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();


            employee.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());
            employee.FirstName = textBoxFirstName.Text;
            employee.LastName = textBoxLastName.Text;
            employee.Email = textBoxEmail.Text;
            employee.PhoneNumber = textBoxPhoneNumber.Text;
            employee.StatusId = Convert.ToInt32(textBoxStatusId.Text);
            employee.JobId = Convert.ToInt32(textBoxJobId.Text);
            EmployeeDB.SaveEmployee(employee);

            MessageBox.Show("Saved Student", "Confirmation");

            textBoxEmployeeId.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            textBoxPhoneNumber.Clear();
            textBoxStatusId.Clear();
            textBoxJobId.Clear();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
