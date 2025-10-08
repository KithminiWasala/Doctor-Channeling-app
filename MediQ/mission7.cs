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
    public partial class mission7 : Form
    {
        public mission7()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            home4 hme = new home4();

            this.Hide();

            hme.Show();
        }
    }
}
