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
    public partial class UserProfileController : Form
    {
        public byte[] image = Login.imageDisplay;
        Image img = null;
        public UserProfileController()
        {
            InitializeComponent();
            usernameDisplay.Text = Login.usernameDisplay;
            idDisplay.Text = Login.user_id.ToString();
            username.Text = Login.usernameDisplay;
            email.Text = Login.emailDisplay;
            firstname.Text = Login.firstnameDisplay;
            lastname.Text = Login.lastnameDisplay;
            pictureBox7.Image = ByteToImage(image);
            pictureBox5.Image = ByteToImage(image);
        }
        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(openFileDialog.FileName);
                pictureBox7.Image = new Bitmap(openFileDialog.FileName);
                if (openFileDialog.CheckFileExists)
                {
                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    image = imgByteArr;

                    pictureBox5.Image = ByteToImage(image);
                }

            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"UPDATE Users SET username =@username, email=@email, first_name= @first_name, last_name = @last_name,user_image=@user_image WHERE user_id = {Login.user_id};";


                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", username.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@first_name", firstname.Text);
                    command.Parameters.AddWithValue("@last_name", lastname.Text);
                    command.Parameters.AddWithValue("@user_image", image);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = img;
            pictureBox7.Image = img;
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT username,email,first_name,last_name,user_image FROM Users WHERE user_id = {Login.user_id};";

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
                            string _username = reader["username"].ToString();
                            string _email = reader["email"].ToString();
                            byte[] _image = (byte[])reader["user_image"];
                            string _firstname = reader["first_name"].ToString();
                            string _lastname = reader["last_name"].ToString();

                            username.Text = _username;
                            email.Text = _email;
                            firstname.Text = _firstname;
                            lastname.Text = _lastname;

                        }
                    }

                    reader.Close();
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            if (newPassword.Text != confirmNewPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = $"UPDATE Users SET password = @password WHERE user_id = {Login.user_id};";


                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@password", newPassword.Text);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
    }
}
