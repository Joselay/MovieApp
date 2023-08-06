namespace MovieSystemManagement
{
    partial class MovieCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieCard));
            movieCardImage = new PictureBox();
            movieCardDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            movieCardTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)movieCardImage).BeginInit();
            SuspendLayout();
            // 
            // movieCardImage
            // 
            movieCardImage.BackColor = Color.Transparent;
            movieCardImage.Cursor = Cursors.Hand;
            movieCardImage.Image = (Image)resources.GetObject("movieCardImage.Image");
            movieCardImage.Location = new Point(7, 4);
            movieCardImage.Name = "movieCardImage";
            movieCardImage.Size = new Size(205, 283);
            movieCardImage.SizeMode = PictureBoxSizeMode.Zoom;
            movieCardImage.TabIndex = 18;
            movieCardImage.TabStop = false;
            movieCardImage.Click += movieCardImage_Click;
            // 
            // movieCardDescription
            // 
            movieCardDescription.AutoSize = false;
            movieCardDescription.BackColor = Color.Transparent;
            movieCardDescription.Font = new Font("Inter", 7.5F, FontStyle.Regular, GraphicsUnit.Point);
            movieCardDescription.ForeColor = Color.FromArgb(123, 123, 125);
            movieCardDescription.Location = new Point(15, 319);
            movieCardDescription.Name = "movieCardDescription";
            movieCardDescription.Size = new Size(196, 40);
            movieCardDescription.TabIndex = 20;
            movieCardDescription.Text = "movieCardDescription";
            // 
            // movieCardTitle
            // 
            movieCardTitle.BackColor = Color.Transparent;
            movieCardTitle.Font = new Font("Inter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            movieCardTitle.ForeColor = Color.White;
            movieCardTitle.Location = new Point(15, 294);
            movieCardTitle.Name = "movieCardTitle";
            movieCardTitle.Size = new Size(124, 21);
            movieCardTitle.TabIndex = 19;
            movieCardTitle.Text = "movieCardTitle";
            // 
            // MovieCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(movieCardImage);
            Controls.Add(movieCardDescription);
            Controls.Add(movieCardTitle);
            Name = "MovieCard";
            Size = new Size(223, 358);
            ((System.ComponentModel.ISupportInitialize)movieCardImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox movieCardImage;
        private Guna.UI2.WinForms.Guna2HtmlLabel movieCardDescription;
        private Guna.UI2.WinForms.Guna2HtmlLabel movieCardTitle;
    }
}
