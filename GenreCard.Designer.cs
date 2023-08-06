namespace MovieSystemManagement
{
    partial class GenreCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenreCard));
            genreCardImage = new PictureBox();
            genreCardTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)genreCardImage).BeginInit();
            SuspendLayout();
            // 
            // genreCardImage
            // 
            genreCardImage.Image = (Image)resources.GetObject("genreCardImage.Image");
            genreCardImage.Location = new Point(-3, 2);
            genreCardImage.Name = "genreCardImage";
            genreCardImage.Size = new Size(261, 168);
            genreCardImage.SizeMode = PictureBoxSizeMode.Zoom;
            genreCardImage.TabIndex = 0;
            genreCardImage.TabStop = false;
            genreCardImage.Click += genreCardImage_Click;
            // 
            // genreCardTitle
            // 
            genreCardTitle.BackColor = Color.Transparent;
            genreCardTitle.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point);
            genreCardTitle.ForeColor = Color.White;
            genreCardTitle.Location = new Point(99, 177);
            genreCardTitle.Name = "genreCardTitle";
            genreCardTitle.Size = new Size(36, 21);
            genreCardTitle.TabIndex = 9;
            genreCardTitle.Text = "Title";
            // 
            // GenreCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(genreCardTitle);
            Controls.Add(genreCardImage);
            Name = "GenreCard";
            Size = new Size(261, 209);
            ((System.ComponentModel.ISupportInitialize)genreCardImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox genreCardImage;
        private Guna.UI2.WinForms.Guna2HtmlLabel genreCardTitle;
    }
}
