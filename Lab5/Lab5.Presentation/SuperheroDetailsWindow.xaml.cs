using System.Windows;
using System.Windows.Media.Imaging;
using Lab5.Domain.Entities;

namespace Lab5
{
    public partial class SuperheroDetailsWindow 
    {
        public SuperheroDetailsWindow(Superhero superhero)
        {
            InitializeComponent();

            NameTextBlock.Text = superhero.Name;
            AliasTextBlock.Text = superhero.Alias;
            PowerLevelTextBlock.Text = superhero.PowerLevel.ToString();
            SuperpowersTextBlock.Text = string.Join(", ", superhero.Superpowers.Select(sp => sp.Name));

            if (superhero.Photo != null && superhero.Photo.Length > 0)
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new System.IO.MemoryStream(superhero.Photo);
                image.EndInit();
                HeroImage.Source = image;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}