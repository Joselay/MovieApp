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
    public partial class ListItems : UserControl
    {
        public static int movieID { get; set; }

        public ListItems()
        {
            InitializeComponent();
        }
        public ListItems(Movie movie)
        {
            InitializeComponent();
            id.Text = movie.movie_id.ToString();
            title.Text = movie.title;
            createdDate.Text = movie.release_date;
            movieID = movie.movie_id;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            movieID = Convert.ToInt32(id.Text);
            UpdateMovie um = new UpdateMovie();
            um.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {


            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                                    "Confirm Delete!!",
                                                                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
                string query = $"DELETE FROM Movie WHERE movie_id = {id.Text};";

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
    }
}
