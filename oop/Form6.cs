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
    public partial class Form6 : Form
    {
        private string loggedInUsername;
        public Form6(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }
        private void MakeFieldsReadOnly()
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtAge.ReadOnly = true;
            txtGender.ReadOnly = true;
            txtMaritalStatus.ReadOnly = true;
            txtLiterate.ReadOnly = true;
            txtDOB.ReadOnly = true;
            txtContactNo.ReadOnly = true;
            txtCNIC.ReadOnly = true;

            txtProvince.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtDistrict.ReadOnly = true;
            txtPostalCode.ReadOnly = true;
            txtPermanentAddress.ReadOnly = true;
            txtCurrentAddress.ReadOnly = true;

            txtFamilyMembers.ReadOnly = true;
            txtReligion.ReadOnly = true;
            txtResidenceType.ReadOnly = true;
            txtIncomeSources.ReadOnly = true;
            txtMonthlyIncome.ReadOnly = true;
            txtTransportAssets.ReadOnly = true;
        }

        private void LoadUserData()
        {
         
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=humaira123;database=OOP;");
            
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM population_survey WHERE first_name = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", loggedInUsername);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["first_name"].ToString();
                        txtLastName.Text = reader["last_name"].ToString();
                        txtAge.Text = reader["age"].ToString();
                        txtGender.Text = reader["gender"].ToString();
                        txtMaritalStatus.Text = reader["marital_status"].ToString();
                        txtLiterate.Text = reader["literate"].ToString();
                        txtDOB.Text = reader["dob"].ToString();
                        txtContactNo.Text = reader["contact_no"].ToString();
                        txtCNIC.Text = reader["cnic"].ToString();
                        txtProvince.Text = reader["province"].ToString();
                        txtCity.Text = reader["city"].ToString();
                        txtDistrict.Text = reader["district"].ToString();
                        txtPostalCode.Text = reader["postal_code"].ToString();
                        txtPermanentAddress.Text = reader["permanent_address"].ToString();
                        txtCurrentAddress.Text = reader["current_address"].ToString();
                        txtFamilyMembers.Text = reader["family_members"].ToString();
                        txtReligion.Text = reader["religion"].ToString();
                        txtResidenceType.Text = reader["residence_type"].ToString();
                        txtIncomeSources.Text = reader["income_sources"].ToString();
                        txtMonthlyIncome.Text = reader["monthly_income"].ToString();
                        txtTransportAssets.Text = reader["transport_assets"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        public Form6()
        {
            InitializeComponent();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MakeFieldsReadOnly();
            LoadUserData();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void personal_Click(object sender, EventArgs e)
        {

        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 n = new Form3();
            n.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
