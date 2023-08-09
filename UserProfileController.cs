using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystemManagement
{
    public partial class UserProfileController : Form
    {
        public UserProfileController()
        {
            InitializeComponent();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
