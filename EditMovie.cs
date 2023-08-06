using Guna.UI2.WinForms;
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
    public partial class EditMovie : Form
    {
        int count = 1;
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
            this.Hide();
            AddMovie am = new AddMovie();
            am.Show();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            this.Show();
            Login l = new Login();
            l.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void publishButton_Click(object sender, EventArgs e)
        {
            Pagination(0);
            one.ForeColor = Color.FromArgb(252, 218, 70);
            two.ForeColor = Color.FromArgb(255, 255, 255);
            three.ForeColor = Color.FromArgb(255, 255, 255);
            four.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            count = 2;
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
            if (one.Text == "1")
                return;
            foreach (Guna2Button button in buttonList)
            {
                button.Text = (Convert.ToInt32(button.Text) - 1).ToString();
                if (button.Text == count.ToString())
                {
                    button.ForeColor = Color.FromArgb(252, 218, 70);
                }
                else
                {
                    button.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }

        }

        private void rightArrow_Click(object sender, EventArgs e)
        {
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
            }

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

    }
}
