using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;

namespace MovieSystemManagement
{
    public partial class ListUsers : UserControl
    {
        public static string displayUsername = "";
        public static string displayId = "";
        public static Image displayImage = null;
        public ListUsers()
        {
            InitializeComponent();


        }
        public ListUsers(Users user)
        {
            InitializeComponent();
            id.Text = user.user_id.ToString();
            name.Text = user.name;
            email.Text = user.email;
            username.Text = user.username;
            subscription.Text = "Free";
            createdDate.Text = user.created_date.ToString();
            pictureBox1.Image = ByteToImage(user.user_image);
        }
        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }



        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                                   "Confirm Delete!!",
                                                                                       MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
                string query = $"DELETE FROM Users WHERE user_id = {id.Text};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();


                        reader.Close();
                        connection.Close();
                    }
                }

            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            displayUsername = username.Text;
            displayId = id.Text;
            displayImage = pictureBox1.Image;
            UserProfile user = new UserProfile();
            user.Show();
        }
    }
}
