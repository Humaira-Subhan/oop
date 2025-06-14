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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

     
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "server=localhost;user=root;password=humaira123;database=OOP;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount == 0)
                {
                    MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

             
                string updateQuery = "UPDATE users SET password = @newPassword WHERE username = @username";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                updateCmd.Parameters.AddWithValue("@username", username);

                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Password has been reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login n = new Login();
                this.Hide();
                n.Show();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1024, 700);
            this.MaximumSize = new Size(1024, 700);
            this.MinimumSize = new Size(1024, 700);
        }
    }
}
