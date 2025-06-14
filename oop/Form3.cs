using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace oop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1024, 700); 
            this.MaximumSize = new Size(1024, 700);
            this.MinimumSize = new Size(1024, 700);
        }
     
        private MySqlConnection GetConnection()
        {
            string connStr = "server=localhost;user=root;password=humaira123;database=OOP;";
            return new MySqlConnection(connStr);
        }

        
        private void LoadDashboardData()
        {
            
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=humaira123;database=OOP;");
            
                try
                {
                    conn.Open();
                    string totalPopQuery = "SELECT SUM(family_members) FROM population_survey";
                    MySqlCommand cmd1 = new MySqlCommand(totalPopQuery, conn);
                    object totalPop = cmd1.ExecuteScalar();
                    lblTotalPopulation.Text = totalPop?.ToString() ?? "0";

                    string surveysQuery = "SELECT COUNT(*) FROM population_survey";
                    MySqlCommand cmd2 = new MySqlCommand(surveysQuery, conn);
                    object surveys = cmd2.ExecuteScalar();
                    lblSurveysSubmitted.Text = surveys?.ToString() ?? "0";

                   
                    string regionsQuery = "SELECT COUNT(DISTINCT city) FROM population_survey";
                    MySqlCommand cmd3 = new MySqlCommand(regionsQuery, conn);
                    object regions = cmd3.ExecuteScalar();
                    lblRegionsCovered.Text = regions?.ToString() ?? "0";

                    
                    string avgHouseQuery = "SELECT AVG(family_members) FROM population_survey";
                    MySqlCommand cmd4 = new MySqlCommand(avgHouseQuery, conn);
                    object avgHouse = cmd4.ExecuteScalar();
                    lblAverageHousehold.Text = avgHouse != DBNull.Value ?
                    Math.Round(Convert.ToDouble(avgHouse), 2).ToString() : "0";

                   
                    string lastUpdateQuery = "SELECT MAX(created_at) FROM population_survey";
                    MySqlCommand cmd5 = new MySqlCommand(lastUpdateQuery, conn);
                    object lastUpdated = cmd5.ExecuteScalar();
                    lblLastUpdated.Text = lastUpdated?.ToString() ?? "N/A";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard:\n" + ex.Message);
                }
            }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 n = new Form4();
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
           
           
            mainPanel.Left = (this.ClientSize.Width - mainPanel.Width) / 2;
            mainPanel.Top = (this.ClientSize.Height - mainPanel.Height) / 2;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 n = new Form5();
            this.Hide();
            n.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
