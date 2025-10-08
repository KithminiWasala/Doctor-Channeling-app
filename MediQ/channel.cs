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
    public partial class channel : Form
    {
        string Doctor;
        public channel()
        {
            InitializeComponent();
            LoadIllnessTypes();
        }
        String DB = Properties.Settings.Default.conDB;


        private void LoadIllnessTypes()
        {
            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(DB);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT IllnessesID, IllnessName FROM Illness", con);
                reader = cmd.ExecuteReader();

                Dictionary<int, string> illnessDict = new Dictionary<int, string>();
                while (reader.Read())
                {
                    illnessDict.Add(reader.GetInt32(0), reader.GetString(1));
                }

                comboBox1.DataSource = new BindingSource(illnessDict, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading illness types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (con != null)
                    con.Close();
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }


        private void LoadDoctors(int illnessID)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(DB);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DoctorID, DoctorName FROM Doctor WHERE IllnessesID = @IllnessID", con);
                cmd.Parameters.AddWithValue("@IllnessID", illnessID);
                reader = cmd.ExecuteReader();

                Dictionary<int, string> doctorDict = new Dictionary<int, string>();
                while (reader.Read())
                {
                    doctorDict.Add(reader.GetInt32(0), reader.GetString(1));
                }

                comboBox2.DataSource = new BindingSource(doctorDict, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";

                if (doctorDict.Count == 0)
                {
                    MessageBox.Show("No doctors found for the selected illness.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (con != null)
                    con.Close();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue is int)
            {
                int selectedIllnessID = (int)comboBox1.SelectedValue;
                LoadDoctors(selectedIllnessID);
            }
        }


        private void channel_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(DB); ;
            String illness = comboBox1.Text;
            String doctor = comboBox2.Text;
            String time = dateTimePicker1.Text;

            try
            {

                con.Open();
                string q = "INSERT INTO ChannelDetails(Illness,Doctor,Time) VALUES ('" + illness + "','" + doctor + "','" + time + "')";
                SqlCommand cc = new SqlCommand(q, con);

                cc.ExecuteNonQuery();






            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading illness types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
             con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DB);


            con.Open();
            SqlCommand Q = new SqlCommand("SELECT Id,Doctor,Time FROM ChannelDetails", con);
            SqlDataReader read = Q.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doctor = comboBox2.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            payment pym = new payment();


            
            this.Hide();
            pym.doctor1=Doctor;
            pym.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

