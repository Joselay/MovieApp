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
    public partial class AddMovie : Form
    {
        byte[] image = null;
        public static int user_id { get; set; }
        public AddMovie()
        {
            InitializeComponent();
            qualityCombo.SelectedIndex = 0;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                uploadCover.Image = new Bitmap(openFileDialog.FileName);
                if (openFileDialog.CheckFileExists)
                {
                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    image = imgByteArr;

                }

            }


        }

        private void publishButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $"INSERT INTO Movie (user_id,director_id,description,rating,duration,release_date,title,movie_image,quality) VALUES(@user_id,@director_id, @description,@rating,@duration,@release_date,@title,@movie_image,@quality);";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.Parameters.AddWithValue("@director_id", 1);
                    command.Parameters.AddWithValue("@description", descriptionText.Text);
                    command.Parameters.AddWithValue("@rating", 9.5);
                    command.Parameters.AddWithValue("@duration", runningTimedInMinutesText.Text);
                    command.Parameters.AddWithValue("@release_date", releaseYearText.Text);
                    command.Parameters.AddWithValue("@title", titleText.Text);
                    command.Parameters.AddWithValue("@movie_image", image);
                    command.Parameters.AddWithValue("@quality", qualityCombo.SelectedItem);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }

        }

        private void editMovie_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMovie em = new EditMovie();
            em.Show();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }

    }
}
