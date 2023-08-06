namespace MovieSystemManagement
{
    partial class ListItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItems));
            id = new Guna.UI2.WinForms.Guna2HtmlLabel();
            title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            createdDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            editButton = new PictureBox();
            deleteButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)editButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deleteButton).BeginInit();
            SuspendLayout();
            // 
            // id
            // 
            id.BackColor = Color.Transparent;
            id.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            id.ForeColor = Color.White;
            id.Location = new Point(33, 28);
            id.Name = "id";
            id.Size = new Size(19, 21);
            id.TabIndex = 0;
            id.Text = "ID";
            // 
            // title
            // 
            title.BackColor = Color.Transparent;
            title.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            title.ForeColor = Color.White;
            title.Location = new Point(279, 28);
            title.Name = "title";
            title.Size = new Size(48, 21);
            title.TabIndex = 1;
            title.Text = "TITLE";
            // 
            // createdDate
            // 
            createdDate.BackColor = Color.Transparent;
            createdDate.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            createdDate.ForeColor = Color.White;
            createdDate.Location = new Point(573, 27);
            createdDate.Name = "createdDate";
            createdDate.Size = new Size(130, 21);
            createdDate.TabIndex = 2;
            createdDate.Text = "CREATED DATE";
            // 
            // editButton
            // 
            editButton.Cursor = Cursors.Hand;
            editButton.Image = (Image)resources.GetObject("editButton.Image");
            editButton.Location = new Point(894, 16);
            editButton.Name = "editButton";
            editButton.Size = new Size(54, 44);
            editButton.SizeMode = PictureBoxSizeMode.CenterImage;
            editButton.TabIndex = 3;
            editButton.TabStop = false;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Image = (Image)resources.GetObject("deleteButton.Image");
            deleteButton.Location = new Point(952, 16);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(54, 44);
            deleteButton.SizeMode = PictureBoxSizeMode.CenterImage;
            deleteButton.TabIndex = 4;
            deleteButton.TabStop = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // ListItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 22, 27);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(createdDate);
            Controls.Add(title);
            Controls.Add(id);
            Name = "ListItems";
            Size = new Size(1194, 75);
            ((System.ComponentModel.ISupportInitialize)editButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)deleteButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel id;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
        private Guna.UI2.WinForms.Guna2HtmlLabel createdDate;
        private PictureBox editButton;
        private PictureBox deleteButton;
    }
}
