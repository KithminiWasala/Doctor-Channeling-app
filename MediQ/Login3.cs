using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediQ
{
    public partial class Login3 : Form
    {
        public Login3()
        {
            InitializeComponent();
        }

        String DB = Properties.Settings.Default.conDB;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        
            {
                // Get the entered name and password
                string name = textBox5.Text.Trim();
                string password = textBox6.Text.Trim();

                // Validate that the fields are not empty
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter both name and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



            // Create SQL connection and query to check for valid credentials
            SqlConnection con = new SqlConnection(DB);
                {
                    try
                    {
                        con.Open();
                        string query = "SELECT COUNT(*) FROM [USER] WHERE Name = @Name AND Password = @Password";

                        // Create SQL command with parameterized query
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Password", password); // Make sure password is stored securely, consider hashing

                            int userCount = (int)cmd.ExecuteScalar(); // Executes the query and gets the result

                            if (userCount > 0)
                            {
                                // User found, login successful
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Proceed to the main form (or another form)
                                this.Hide();
                                home4 mainForm = new home4();  // Assuming MainForm is the main application window
                                mainForm.Show();
                            }
                            else
                            {
                                // Invalid credentials
                                MessageBox.Show("Invalid name or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
              
        }

        private void label1_Click(object sender, EventArgs e)
        {
            register2 reg = new register2();    

            this.Hide();

            reg.Show();
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == "")
            {

                errorProvider1.SetError(textBox5, "Please enter  USERNAME.");
                e.Cancel = true;
            }
            else {
                errorProvider1.SetError(textBox5, "Please enter valid USERNAME. ");
                
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == "")
            {

                errorProvider1.SetError(textBox6, "Please enter  Password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox6, "Please enter valid password. ");
                
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
