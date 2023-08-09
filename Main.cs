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

namespace MovieSystemManagement
{
    public partial class Main : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public Main()
        {
            InitializeComponent();
            ApplyRoundedCorners();

            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT * FROM Movie;";

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
                            int user_id = (int)reader["user_id"];
                            int director_id = (int)reader["director_id"];
                            string description = (string)reader["description"];
                            string title = (string)reader["title"];
                            byte[] image = (byte[])reader["movie_image"];

                            Movie movie = new Movie(title, description, image);
                            MovieCard mc = new MovieCard(movie);
                            mainFlow.Controls.Add(mc);

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
        private void ApplyRoundedCorners()
        {
            const int cornerRadius = 20;

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
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Genre genre = new Genre();
            genre.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UserProfile up = new UserProfile();
            up.Show();
        }
    }
}
