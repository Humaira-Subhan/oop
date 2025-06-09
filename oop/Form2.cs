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
using System.Drawing.Drawing2D;
namespace oop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string connectionString = "server=localhost;uid=root;pwd=humaira123;database=oop;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            {
                conn.Open();
                string query = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);  

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Signup successful! You can now log in.");
                    this.Hide();
                    new Login().Show(); 
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
