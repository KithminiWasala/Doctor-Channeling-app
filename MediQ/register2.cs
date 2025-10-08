using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediQ
{
    public partial class register2 : Form
    {
        public register2()
        {
            InitializeComponent();
        }

        String DB = Properties.Settings.Default.conDB;
        private object con;

        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Contact { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            Login3 lgn = new Login3();

            // Corrected database connection (use relative path if needed)
            SqlConnection con = new SqlConnection(DB);
            {
                try
                {
                    // Validate input fields
                    if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                        string.IsNullOrWhiteSpace(textBox2.Text) ||
                        string.IsNullOrWhiteSpace(textBox3.Text) ||
                        string.IsNullOrWhiteSpace(textBox4.Text) ||
                        string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string name = textBox1.Text.Trim();
                    int age;
                    long contact;
                    string email = textBox4.Text.Trim();
                    string password = textBox5.Text.Trim(); // Fixed incorrect assignment

                    // Validate numeric fields
                    if (!int.TryParse(textBox2.Text.Trim(), out age))
                    {
                        MessageBox.Show("Invalid Age! Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!long.TryParse(textBox3.Text.Trim(), out contact))
                    {
                        MessageBox.Show("Invalid Contact Number! Only numbers are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Open the connection
                    con.Open();
                    string InsertQ = "INSERT INTO [user] (Name, Age, Contact, Email, Password) VALUES (@Name, @Age, @Contact, @Email, @Password)";

                    using (SqlCommand cmd = new SqlCommand(InsertQ, con))
                    {
                        // Use parameterized queries to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@Contact", contact);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Consider hashing for security

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Insert Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to login
                    this.Hide();
                    lgn.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // `using` ensures `con.Close()` is called automatically

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "") {

                errorProvider1.SetError(textBox1, "You should enter the your name.");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == "")
            {

                errorProvider1.SetError(textBox2, "You should enter the your age.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string contactPattern = @"^0\d{9}$"; // Must start with '0' and be exactly 10 digits

            if (string.IsNullOrWhiteSpace(textBox3.Text) || !Regex.IsMatch(textBox3.Text, contactPattern))
            {
                errorProvider1.SetError(textBox3, "Contact number must start with '0' and be exactly 10 digits long.");
               
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == "")
            {

                errorProvider1.SetError(textBox3, "You should enter the your Contact.");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == "")
            {

                errorProvider1.SetError(textBox4, "You should enter the your Email.");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == "")
            {

                errorProvider1.SetError(textBox5, "You should enter the your Password.");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == "")
            {

                errorProvider1.SetError(textBox6, "You should enter the your name.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(textBox4.Text) || !Regex.IsMatch(textBox4.Text, emailPattern))
            {
                errorProvider1.SetError(textBox4, "Enter a valid Email (e.g., example@domain.com).");
                 
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string passwordPattern = @"^\d{8,}$"; // Only numbers, at least 8 digits

            if (string.IsNullOrWhiteSpace(textBox5.Text) || !Regex.IsMatch(textBox5.Text, passwordPattern))
            {
                errorProvider1.SetError(textBox5, "Password must be at least 8 digits long and contain only numbers.");
                 
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }
        }
    }
    }

