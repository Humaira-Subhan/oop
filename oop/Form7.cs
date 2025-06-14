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
    public partial class Form7 : Form
    {

        public Form7()
        {
            InitializeComponent();
        }
        private void LoadAllData()
        {
            string connStr = "server=localhost;user=root;password=humaira123;database=OOP;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM population_survey";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadAllData();
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
            this.Size = new Size(1024, 700);
            this.MaximumSize = new Size(1024, 700);
            this.MinimumSize = new Size(1024, 700);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["id"].Value);
                string firstName = row.Cells["first_name"].Value?.ToString();
                string lastName = row.Cells["last_name"].Value?.ToString();
                int age = Convert.ToInt32(row.Cells["age"].Value);
                string gender = row.Cells["gender"].Value?.ToString();
                string maritalStatus = row.Cells["marital_status"].Value?.ToString();
                bool literate = Convert.ToBoolean(row.Cells["literate"].Value);
                DateTime dob = Convert.ToDateTime(row.Cells["dob"].Value);
                string contactNo = row.Cells["contact_no"].Value?.ToString();
                string cnic = row.Cells["cnic"].Value?.ToString();

                string province = row.Cells["province"].Value?.ToString();
                string city = row.Cells["city"].Value?.ToString();
                string district = row.Cells["district"].Value?.ToString();
                string postalCode = row.Cells["postal_code"].Value?.ToString();
                string permanentAddress = row.Cells["permanent_address"].Value?.ToString();
                string currentAddress = row.Cells["current_address"].Value?.ToString();

                int familyMembers = Convert.ToInt32(row.Cells["family_members"].Value);
                string religion = row.Cells["religion"].Value?.ToString();
                string residenceType = row.Cells["residence_type"].Value?.ToString();
                string incomeSources = row.Cells["income_sources"].Value?.ToString();
                string monthlyIncome = row.Cells["monthly_income"].Value?.ToString();
                string transportAssets = row.Cells["transport_assets"].Value?.ToString();

                string connStr = "server=localhost;user=root;password=humaira123;database=OOP;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string query = @"UPDATE population_survey 
                                 SET first_name=@firstName, last_name=@lastName, age=@age, gender=@gender,
                                     marital_status=@maritalStatus, literate=@literate, dob=@dob,
                                     contact_no=@contactNo, cnic=@cnic, province=@province, city=@city,
                                     district=@district, postal_code=@postalCode, permanent_address=@permanentAddress,
                                     current_address=@currentAddress, family_members=@familyMembers, religion=@religion,
                                     residence_type=@residenceType, income_sources=@incomeSources,
                                     monthly_income=@monthlyIncome, transport_assets=@transportAssets
                                 WHERE id=@id";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@maritalStatus", maritalStatus);
                        cmd.Parameters.AddWithValue("@literate", literate);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@contactNo", contactNo);
                        cmd.Parameters.AddWithValue("@cnic", cnic);
                        cmd.Parameters.AddWithValue("@province", province);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@district", district);
                        cmd.Parameters.AddWithValue("@postalCode", postalCode);
                        cmd.Parameters.AddWithValue("@permanentAddress", permanentAddress);
                        cmd.Parameters.AddWithValue("@currentAddress", currentAddress);
                        cmd.Parameters.AddWithValue("@familyMembers", familyMembers);
                        cmd.Parameters.AddWithValue("@religion", religion);
                        cmd.Parameters.AddWithValue("@residenceType", residenceType);
                        cmd.Parameters.AddWithValue("@incomeSources", incomeSources);
                        cmd.Parameters.AddWithValue("@monthlyIncome", monthlyIncome);
                        cmd.Parameters.AddWithValue("@transportAssets", transportAssets);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully.");
                        LoadAllData(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update failed: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    string connStr = "server=localhost;user=root;password=humaira123;database=OOP;";
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM population_survey WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Record deleted successfully.");
                            LoadAllData(); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Delete failed: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 n = new Form3();
            this.Hide();
            n.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
