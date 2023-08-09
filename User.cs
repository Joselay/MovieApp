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

namespace MovieSystemManagement
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT * FROM Users WHERE role = 'user';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int user_id = reader.GetInt32(0);
                            string email = reader.GetString(1);
                            string password = reader.GetString(2);
                            string role = reader.GetString(3);
                            string first_name = reader.GetString(4);
                            string last_name = reader.GetString(5);
                            byte[] image = (byte[])reader[6];
                            string username = reader.GetString(7);

                        }
                    }

                    reader.Close();
                }
            }

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            UserProfile up = new UserProfile();
            up.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
