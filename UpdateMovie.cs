using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Added

namespace MovieSystemManagement
{
    public partial class UpdateMovie : Form
    {
        int movie_id = ListItems.movieID;
        public UpdateMovie()
        {
            InitializeComponent();

            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT title,description,YEAR(release_date) AS release_date,movie_image,duration FROM Movie WHERE movie_id = {movie_id};";

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
                            string title = (string)reader["title"];
                            string description = (string)reader["description"];
                            int year = Convert.ToInt32(reader["release_date"]);
                            int duration = (int)reader["duration"];

                            titleText.Text = title;
                            descriptionText.Text = description;
                            releaseYearText.Text = year.ToString();
                            runningTimedInMinutesText.Text = duration.ToString();
                            uploadCover.Image = ByteToImage((byte[])reader["movie_image"]);

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
        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }


        private void editMovie_Click(object sender, EventArgs e)
        {
            EditMovie em = new EditMovie();
            em.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $"UPDATE Movie SET title=@title, description = @description,release_date = @release_date,duration=@duration WHERE movie_id={movie_id};";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@title", titleText.Text);
                    command.Parameters.AddWithValue("@description", descriptionText.Text);
                    command.Parameters.AddWithValue("@release_date", releaseYearText.Text);
                    command.Parameters.AddWithValue("@duration", runningTimedInMinutesText.Text);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }
    }
}
