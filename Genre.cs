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


namespace MovieSystemManagement
{
    public partial class Genre : Form
    {
        public Genre()
        {
            InitializeComponent();
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT TOP 4 description,title,movie_image FROM Movie;";

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
                            string description = (string)reader["description"];
                            string title = (string)reader["title"];
                            byte[] image = (byte[])reader["movie_image"];

                            Movie movie = new Movie(title, description, image);
                            GenreCard mc = new GenreCard(movie);
                            genreFirstLayout.Controls.Add(mc);
                            GenreCard mc1 = new GenreCard(movie);
                            genreSecondLayout.Controls.Add(mc1);

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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void Genre_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Watchlist wl = new Watchlist();
            wl.Show();
        }
    }
}
