using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace MovieSystemManagement
{
    public partial class Login : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public Login()
        {
            InitializeComponent();

            loginPanel.FillColor = Color.FromArgb(205, 12, 11, 16);

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

        private void Login_Load(object sender, EventArgs e)
        {

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

        private void signupLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=JOSE;Initial Catalog=MovieApp;User ID=jose;Password=jose";
            string query = $"SELECT * FROM Users WHERE email = '{emailText.Text}';";

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
                            int userId = (int)reader["user_id"];
                            string email = (string)reader["email"];
                            string password = (string)reader["password"];
                            string role = (string)reader["role"];
                            string first_name = (string)reader["first_name"];
                            string last_name = (string)reader["last_name"];

                            Users user = new Users(userId, email, password, role, first_name, last_name);
                            AddMovie.user_id = user.user_id;
                            if (email == emailText.Text && password == passwordText.Text)
                            {
                                if (role == "admin")
                                {
                                    this.Hide();
                                    EditMovie am = new EditMovie();
                                    am.Show();
                                }
                                else if (role == "user" || role == "guest")
                                {
                                    this.Hide();
                                    Main main = new Main();
                                    main.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email or password is incorrect");
                            }
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

        private void passwordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }
    }
}