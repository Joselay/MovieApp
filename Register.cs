using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieSystemManagement
{
    public partial class Register : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public Register()
        {
            InitializeComponent();
            registerPanel.FillColor = Color.FromArgb(205, 12, 11, 16);
            ApplyRoundedCorners();
        }
        private void ApplyRoundedCorners()
        {
            const int cornerRadius = 30;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(Width - (cornerRadius * 2), 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(Width - (cornerRadius * 2), Height - (cornerRadius * 2), cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(0, Height - (cornerRadius * 2), cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseAllFigures();

            Region = new Region(path);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void loginLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";

            string query = "INSERT INTO Users (email, password,role,first_name,last_name,username) VALUES (@email, @password,@role,@first_name,@last_name,@username)";

            if (passwordText.Text != confirmPasswordText.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Create a SqlConnection object to connect to the database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with the query and the connection.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                        command.Parameters.AddWithValue("@email", emailText.Text);
                        command.Parameters.AddWithValue("@password", passwordText.Text);
                        command.Parameters.AddWithValue("@role", "user");
                        command.Parameters.AddWithValue("@first_name", firstNameText.Text);
                        command.Parameters.AddWithValue("@last_name", lastNameText.Text);
                        command.Parameters.AddWithValue("@username", firstNameText.Text + lastNameText.Text);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            this.Hide();
                            Login login = new Login();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("No data inserted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
