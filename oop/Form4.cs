using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string ageText = txtAge.Text.Trim();

            string gender = "";
            if (radioMale.Checked) gender = "male";
            else if (radioFemale.Checked) gender = "female";
            else if (radioOther.Checked) gender = "others";

            string maritalStatus = radioMarried.Checked ? "married" : "single";
            bool literate = radioLiterateYes.Checked || radioLiterateNo.Checked;

            DateTime dob = dateTimePicker1.Value;
            string contactNo = txtContact.Text.Trim();
            string cnic = txtCNIC.Text.Trim();

        
            string province = textBox9.Text.Trim();
            string city = txtCity.Text.Trim();
            string district = txtDistrict.Text.Trim();
            string postalCode = textBox6.Text.Trim();
            string permanentAddress = txtPermanentAddress.Text.Trim();
            string currentAddress = txtCurrentAddress.Text.Trim();

          
            string familyText = txtFamilyMembers.Text.Trim();
            string religion = cmbReligion.SelectedItem?.ToString();
            string residenceType = comboBox2.SelectedItem?.ToString();

            List<string> incomeSources = new List<string>();
            foreach (var item in checkedListIncomeSources.CheckedItems)
            {
                incomeSources.Add(item.ToString());
            }
            string incomeSourcesStr = string.Join(",", incomeSources);

            string monthlyIncome = txtMonthlyIncome.Text.Trim();

            List<string> transportAssets = new List<string>();
            foreach (var item in checkedListVehicleOwnership.CheckedItems)
            {
                transportAssets.Add(item.ToString());
            }
            string transportAssetsStr = string.Join(",", transportAssets);

            // === VALIDATION ===
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(ageText) ||
                string.IsNullOrWhiteSpace(gender) || !literate || string.IsNullOrWhiteSpace(contactNo) || string.IsNullOrWhiteSpace(cnic) ||
                string.IsNullOrWhiteSpace(province) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(district) ||
                string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(permanentAddress) || string.IsNullOrWhiteSpace(currentAddress) ||
                string.IsNullOrWhiteSpace(familyText) || string.IsNullOrWhiteSpace(religion) || string.IsNullOrWhiteSpace(residenceType) ||
                incomeSources.Count == 0 || string.IsNullOrWhiteSpace(monthlyIncome) || transportAssets.Count == 0)
            {
                MessageBox.Show("Please fill in all required fields and make at least one selection where needed.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ageText, out int age) || !int.TryParse(familyText, out int familyMembers))
            {
                MessageBox.Show("Age and Family Members must be valid numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // === DATABASE CONNECTION ===
            string connStr = "server=localhost;user=root;password=humaira123;database=OOP";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO population_survey 
            (first_name, last_name, age, gender, marital_status, literate, dob, contact_no, cnic, 
            province, city, district, postal_code, permanent_address, current_address, 
            family_members, religion, residence_type, income_sources, monthly_income, transport_assets)
            VALUES 
            (@first_name, @last_name, @age, @gender, @marital_status, @literate, @dob, @contact_no, @cnic, 
            @province, @city, @district, @postal_code, @permanent_address, @current_address, 
            @family_members, @religion, @residence_type, @income_sources, @monthly_income, @transport_assets)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@marital_status", maritalStatus);
                    cmd.Parameters.AddWithValue("@literate", radioLiterateYes.Checked);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@contact_no", contactNo);
                    cmd.Parameters.AddWithValue("@cnic", cnic);
                    cmd.Parameters.AddWithValue("@province", province);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@district", district);
                    cmd.Parameters.AddWithValue("@postal_code", postalCode);
                    cmd.Parameters.AddWithValue("@permanent_address", permanentAddress);
                    cmd.Parameters.AddWithValue("@current_address", currentAddress);
                    cmd.Parameters.AddWithValue("@family_members", familyMembers);
                    cmd.Parameters.AddWithValue("@religion", religion);
                    cmd.Parameters.AddWithValue("@residence_type", residenceType);
                    cmd.Parameters.AddWithValue("@income_sources", incomeSourcesStr);
                    cmd.Parameters.AddWithValue("@monthly_income", monthlyIncome);
                    cmd.Parameters.AddWithValue("@transport_assets", transportAssetsStr);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Survey submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 n = new Form3();
            n.Show();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

