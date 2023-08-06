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
    public partial class GenreCard : UserControl
    {
        public GenreCard()
        {
            InitializeComponent();
        }
        public GenreCard(Movie movie)
        {
            InitializeComponent();
            genreCardTitle.Text = movie.title;
            genreCardImage.Image = ByteToImage(movie.movie_image);
        }
        public Image ByteToImage(byte[] blob)
        {
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(blob);
        }


        private void genreCardImage_Click(object sender, EventArgs e)
        {

        }
    }
}
