using Guna.UI2.WinForms;
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
    public partial class UserProfile : Form
    {
        byte[] image = null;
        public UserProfile()
        {
            InitializeComponent();
            displayUsername.Text = ListUsers.displayUsername;
            id.Text = ListUsers.displayId;
            pictureBox6.Image = ListUsers.displayImage;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMovie editMovie = new EditMovie();
            editMovie.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {


            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO Users (email,password,role,first_name,last_name,user_image,username,created_date) VALUES(@email,@password,@role,@first_name,@last_name,@user_image, @username,@created_date);";


                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@password", password.Text);
                    command.Parameters.AddWithValue("@role", "user");
                    command.Parameters.AddWithValue("@first_name", firstname.Text);
                    command.Parameters.AddWithValue("@last_name", lastname.Text);
                    command.Parameters.AddWithValue("@user_image", image);
                    command.Parameters.AddWithValue("@username", username.Text);
                    command.Parameters.AddWithValue("@created_date", DateTime.Today);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }


        }
        public static Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }

        private void userImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                userImage.Image = new Bitmap(openFileDialog.FileName);
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $"UPDATE Users SET username=@username,email=@email, first_name=@first_name,last_name=@last_name WHERE user_id = {ListUsers.displayId};";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", usernameProfile.Text);
                    command.Parameters.AddWithValue("@email", emailProfile.Text);
                    command.Parameters.AddWithValue("@first_name", firstnameProfile.Text);
                    command.Parameters.AddWithValue("@last_name", lastnameProfile.Text);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            this.Hide();
        }
    }
}
