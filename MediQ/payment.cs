using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cal;

namespace MediQ
{
    public partial class payment : Form
    {
      
        public string doctor1 { get; set; }
        public payment()
        {
            InitializeComponent();
        }
        
    private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = 50;
            double b = 10;
            double c = .1;

            try
            {
                double answer = math.mul(a, b);


                try
                {
                    double dis = math.dis(answer, c);

                    MessageBox.Show("TOTAL CHANNELING FEE : $" + dis);

                    thnk thnk = new thnk();
                    this.Hide();
                    thnk.Show();
                    



                }
                catch (Exception ex) {

                    MessageBox.Show(ex.Message);

                }
                




                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = 50;
            double b = 10;

            try
            {
                double answer = math.mul(a, b);


                MessageBox.Show("YOUR TOTAL FEE: $" + answer + 
                    "\n!~ YOU CAN PAY IT PHYSICALY ~! ");

                thnk thnk = new thnk();
                this.Hide();
                thnk.Show();






            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = doctor1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
