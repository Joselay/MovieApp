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
        public EditMovie()
        {
            InitializeComponent();

            showListMovie();
        }
        public void showListMovie()
        {
            flowLayoutPanel1.Controls.Clear();
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT movie_id, title,release_date FROM Movie;";

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
            showListMovie();
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
            string query = $"SELECT movie_id, title,release_date FROM Movie WHERE title LIKE '{searchText.Text}%';";

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
    }
}
