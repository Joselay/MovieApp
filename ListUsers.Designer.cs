namespace MovieSystemManagement
{
    partial class ListUsers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListUsers));
            id = new Guna.UI2.WinForms.Guna2HtmlLabel();
            name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            email = new Guna.UI2.WinForms.Guna2HtmlLabel();
            username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            subscription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            createdDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            deleteButton = new PictureBox();
            editButton = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)deleteButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // id
            // 
            id.BackColor = Color.Transparent;
            id.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            id.ForeColor = Color.White;
            id.Location = new Point(27, 25);
            id.Name = "id";
            id.Size = new Size(19, 21);
            id.TabIndex = 1;
            id.Text = "ID";
            // 
            // name
            // 
            name.BackColor = Color.Transparent;
            name.Font = new Font("Inter", 11.249999F, FontStyle.Bold, GraphicsUnit.Point);
            name.ForeColor = Color.White;
            name.Location = new Point(187, 14);
            name.Name = "name";
            name.Size = new Size(46, 21);
            name.TabIndex = 2;
            name.Text = "Name";
            // 
            // email
            // 
            email.BackColor = Color.Transparent;
            email.Font = new Font("Inter", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            email.ForeColor = Color.FromArgb(123, 123, 125);
            email.Location = new Point(187, 41);
            email.Name = "email";
            email.Size = new Size(121, 18);
            email.TabIndex = 4;
            email.Text = "amjose@gmail.com";
            // 
            // username
            // 
            username.BackColor = Color.Transparent;
            username.Font = new Font("Inter", 10F, FontStyle.Bold, GraphicsUnit.Point);
            username.ForeColor = Color.White;
            username.Location = new Point(436, 28);
            username.Name = "username";
            username.Size = new Size(68, 18);
            username.TabIndex = 5;
            username.Text = "Username";
            // 
            // subscription
            // 
            subscription.BackColor = Color.Transparent;
            subscription.Font = new Font("Inter", 10F, FontStyle.Bold, GraphicsUnit.Point);
            subscription.ForeColor = Color.White;
            subscription.Location = new Point(637, 28);
            subscription.Name = "subscription";
            subscription.Size = new Size(32, 18);
            subscription.TabIndex = 6;
            subscription.Text = "Free";
            // 
            // createdDate
            // 
            createdDate.BackColor = Color.Transparent;
            createdDate.Font = new Font("Inter", 10F, FontStyle.Bold, GraphicsUnit.Point);
            createdDate.ForeColor = Color.White;
            createdDate.Location = new Point(782, 28);
            createdDate.Name = "createdDate";
            createdDate.Size = new Size(82, 18);
            createdDate.TabIndex = 7;
            createdDate.Text = "16 Oct 2003";
            // 
            // deleteButton
            // 
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
            deleteButton.Location = new Point(990, 15);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(54, 44);
            deleteButton.SizeMode = PictureBoxSizeMode.CenterImage;
            deleteButton.TabIndex = 9;
            deleteButton.TabStop = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // editButton
            // 
            editButton.Cursor = Cursors.Hand;
            editButton.Image = (Image)resources.GetObject("editButton.Image");
            editButton.Location = new Point(940, 15);
            editButton.Name = "editButton";
            editButton.Size = new Size(54, 44);
            editButton.SizeMode = PictureBoxSizeMode.CenterImage;
            editButton.TabIndex = 8;
            editButton.TabStop = false;
            editButton.Click += editButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(72, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // ListUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 22, 27);
            Controls.Add(pictureBox1);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(createdDate);
            Controls.Add(subscription);
            Controls.Add(username);
            Controls.Add(email);
            Controls.Add(name);
            Controls.Add(id);
            Name = "ListUsers";
            Size = new Size(1194, 75);
            ((System.ComponentModel.ISupportInitialize)deleteButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel id;
        private Guna.UI2.WinForms.Guna2HtmlLabel name;
        private Guna.UI2.WinForms.Guna2HtmlLabel email;
        private Guna.UI2.WinForms.Guna2HtmlLabel username;
        private Guna.UI2.WinForms.Guna2HtmlLabel subscription;
        private Guna.UI2.WinForms.Guna2HtmlLabel createdDate;
        private PictureBox deleteButton;
        private PictureBox editButton;
        private PictureBox pictureBox1;
    }
}
