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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 700);
            this.MaximumSize = new Size(1024, 700);
            this.MinimumSize = new Size(1024, 700);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            string connStr = "server=localhost;user=root;password=humaira123;database=OOP;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (username.ToLower() == "admin")
                        {
                            
                            Form7 adminPage = new Form7();
                            this.Hide();
                            adminPage.Show();
                        }
                        else
                        {
                         
                            Form6 userPage = new Form6(username);
                            this.Hide();
                            userPage.Show();
                        }

                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

