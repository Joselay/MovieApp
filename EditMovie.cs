using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystemManagement
{
    public partial class EditMovie : Form
    {
        int count = 1;
        int n = 0;
        int pos = 0;
        string buttonText = "";
        static int row = 8;
        List<Guna2Button> buttonList = new List<Guna2Button>();
        public EditMovie()
        {
            InitializeComponent();

            Pagination(0);
            one.ForeColor = Color.FromArgb(252, 218, 70);


            buttonList.Add(one);
            buttonList.Add(two);
            buttonList.Add(three);
            buttonList.Add(four);
        }



        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        public int COUNT()
        {
            string stmt = "SELECT COUNT(*) FROM Movie;";
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
        private void addButton_Click(object sender, EventArgs e)
        {
            AddMovie am = new AddMovie();
            am.Show();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT TOP 8 movie_id, title,release_date FROM Movie WHERE title LIKE '{searchText.Text}%';";

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
                            int movie_id = (int)reader["movie_id"];
                            string title = (string)reader["title"];
                            string release_date = ((DateTime)reader["release_date"]).ToString();


                            Movie movie = new Movie(movie_id, title, release_date);
                            ListItems li = new ListItems(movie);
                            flowLayoutPanel1.Controls.Add(li);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data");
                    }

                    reader.Close();
                }
            }

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

        public void Pagination(int row)
        {
            flowLayoutPanel1.Controls.Clear();

            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT movie_id, title,release_date FROM Movie ORDER BY movie_id OFFSET {row} ROWS FETCH NEXT 8 ROWS ONLY;";

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
                            int movie_id = (int)reader["movie_id"];

                            string title = (string)reader["title"];
                            string release_date = ((DateTime)reader["release_date"]).ToString();

                            Movie movie = new Movie(movie_id, title, release_date);
                            ListItems li = new ListItems(movie);
                            flowLayoutPanel1.Controls.Add(li);
                        }
                    }

                    reader.Close();
                }
            }

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Hide();
            User user = new User();
            user.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
