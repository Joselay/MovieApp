using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSystemManagement
{
    public partial class MovieCard : UserControl
    {
        public MovieCard()
        {
            InitializeComponent();

        }
        public MovieCard(Movie movie)
        {
            InitializeComponent();
            movieCardTitle.Text = movie.title;
            movieCardDescription.Text = movie.description;

            movieCardImage.Image = ByteToImage(movie.movie_image);
        }
        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }

        private void movieCardImage_Click(object sender, EventArgs e)
        {
        }
    }
}
