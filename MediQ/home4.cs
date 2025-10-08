using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediQ
{
    public partial class home4 : Form
    {
        public home4()
        {
            InitializeComponent();
        }

        private void home4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            aboutus5 abts = new aboutus5();

            this.Hide();

            abts.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vision6 vshn = new vision6();   
            this.Hide();

            vshn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mission7 mssn = new mission7();

            this.Hide();

            mssn.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            channel chn = new channel();

            this.Hide();

            chn.Show();
        }
    }
}
