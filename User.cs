using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystemManagement
{
    public partial class User : Form
    {
        int count = 1;
        int n = 0;
        int pos = 0;
        string buttonText = "";
        static int row = 8;
        List<Guna2Button> buttonList = new List<Guna2Button>();
        public User()
        {
            InitializeComponent();
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT *,FORMAT(created_Date, 'dd MMM yyyy') AS date FROM Users WHERE role = 'user';";

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
                            string date = reader.GetString(9);

                            Users user = new Users(user_id, email, password, role, first_name, last_name, image, username, date);
                            ListUsers listUser = new ListUsers(user);
                            listUsers.Controls.Add(listUser);

                        }
                    }

                    reader.Close();
                }
            }

            Pagination(0);
            one.ForeColor = Color.FromArgb(252, 218, 70);


            buttonList.Add(one);
            buttonList.Add(two);
            buttonList.Add(three);
            buttonList.Add(four);


        }
        private void one_Click(object sender, EventArgs e)
        {
            count = 1;
            buttonText = one.Text;
            n = (Convert.ToInt32(one.Text) - 1) * 8;

            int row = ((Convert.ToInt32(one.Text) - 1) * 8);
            Pagination(row);

            foreach (Guna2Button button in buttonList)
            {
                if (button == one)
                {
                    string query = $"SELECT movie_id, title,release_date FROM Movie ORDER BY movie_id OFFSET {row} ROWS FETCH NEXT 8 ROWS ONLY;";
                    button.ForeColor = Color.FromArgb(252, 218, 70);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }

        }

        private void two_Click(object sender, EventArgs e)
        {
            buttonText = two.Text;
            count = 2;
            n = (Convert.ToInt32(two.Text) - 1) * 8;
            int row = ((Convert.ToInt32(two.Text) - 1) * 8);
            Pagination(row);
            foreach (Guna2Button button in buttonList)
            {
                if (button == two)
                {
                    string query = $"SELECT movie_id, title,release_date FROM Movie ORDER BY movie_id OFFSET {row} ROWS FETCH NEXT 8 ROWS ONLY;";
                    button.ForeColor = Color.FromArgb(252, 218, 70);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }


        }

        private void three_Click(object sender, EventArgs e)
        {
            buttonText = three.Text;
            n = (Convert.ToInt32(three.Text) - 1) * 8;
            count = 3;
            int row = ((Convert.ToInt32(three.Text) - 1) * 8);

            Pagination(row);




            foreach (Guna2Button button in buttonList)
            {
                if (button == three)
                {
                    button.ForeColor = Color.FromArgb(252, 218, 70);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }


        }

        private void four_Click(object sender, EventArgs e)
        {
            buttonText = four.Text;
            n = (Convert.ToInt32(four.Text) - 1) * 8;
            count = 4;
            int row = ((Convert.ToInt32(four.Text) - 1) * 8);
            Pagination(row);
            foreach (Guna2Button button in buttonList)
            {
                if (button == four)
                {
                    string query = $"SELECT movie_id, title,release_date FROM Movie ORDER BY movie_id OFFSET {row} ROWS FETCH NEXT 8 ROWS ONLY;";
                    button.ForeColor = Color.FromArgb(252, 218, 70);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        private void leftArrow_Click(object sender, EventArgs e)
        {
            one.Text = "1";
            two.Text = "2";
            three.Text = "3";
            four.Text = "4";
            Pagination(0);
            one.ForeColor = Color.FromArgb(252, 218, 70);
            two.ForeColor = Color.FromArgb(255, 255, 255);
            three.ForeColor = Color.FromArgb(255, 255, 255);
            four.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void rightArrow_Click(object sender, EventArgs e)
        {
            /*
            foreach (Guna2Button button in buttonList)
            {
                button.Text = (Convert.ToInt32(button.Text) + 1).ToString();

                if (button.Text == count.ToString())
                {
                    button.ForeColor = Color.FromArgb(252, 218, 70);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }*/
            double total = Math.Ceiling((double)COUNT() / 8);

            four.Text = total.ToString();
            three.Text = (Convert.ToInt32(four.Text) - 1).ToString();

            two.Text = (Convert.ToInt32(three.Text) - 1).ToString();
            one.Text = (Convert.ToInt32(two.Text) - 1).ToString();

            four.ForeColor = Color.FromArgb(252, 218, 70);

            two.ForeColor = Color.FromArgb(255, 255, 255);
            three.ForeColor = Color.FromArgb(255, 255, 255);
            one.ForeColor = Color.FromArgb(255, 255, 255);

            int row = ((Convert.ToInt32(total) - 1) * 8);
            Pagination(row);

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

        public void Pagination(int row)
        {
            listUsers.Controls.Clear();

            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            //string query = $"SELECT movie_id, title,release_date FROM Movie ORDER BY movie_id OFFSET {row} ROWS FETCH NEXT 8 ROWS ONLY;";
            string query = $"SELECT *,FORMAT(created_Date, 'dd MMM yyyy') AS date FROM Users WHERE role ='user' ORDER BY user_id OFFSET {row} ROWS FETCH NEXT 8 ROWS ONLY;";


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
                            string name = reader["first_name"] + " " + reader["last_name"];
                            string username = reader.GetString(7);
                            string subscription = "Free";
                            string date = reader.GetString(9);
                            byte[] image = (byte[])reader["user_image"];

                            Users user = new Users(user_id, email, name, username, subscription, date, image);
                            ListUsers li = new ListUsers(user);
                            listUsers.Controls.Add(li);
                        }
                    }

                    reader.Close();
                }
            }

        }
        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }


        private void publishButton_Click(object sender, EventArgs e)
        {
            Pagination(n);
            pos = Convert.ToInt32(four.Text) * 8 - COUNT();
            if (pos >= 8)
            {
                four.Text = (Convert.ToInt32(four.Text) - 1).ToString();
                three.Text = (Convert.ToInt32(three.Text) - 1).ToString();
                two.Text = (Convert.ToInt32(two.Text) - 1).ToString();
                one.Text = (Convert.ToInt32(one.Text) - 1).ToString();

                Pagination(Convert.ToInt32(three.Text) * 8 - 1);

            }
        }
        public int COUNT()
        {
            string stmt = "SELECT COUNT(*) FROM Users;";
            int count = 0;

            using (SqlConnection thisConnection = new SqlConnection("Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
    }
}
