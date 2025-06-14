using MySql.Data.MySqlClient;
using System;

using System.Drawing;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Drawing2D;

namespace oop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
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
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd=humaira123;database=oop;");
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                   
                    this.Hide();
                    new Form3().Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form8 n = new Form8();
            this.Hide();
            n.Show();
        }
    }
}
