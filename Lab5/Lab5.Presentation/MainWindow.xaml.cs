using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Lab5.Domain.Entities;
using Lab5.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Superhero> Superheroes { get; set; }
        private readonly ApplicationDbContext _context;

        public MainWindow(ApplicationDbContext context)
        {
            InitializeComponent();
            _context = context;

            Superheroes = new ObservableCollection<Superhero>();
            HeroesListBox.ItemsSource = Superheroes;

            LoadSuperheroes();
        }

        private async void LoadSuperheroes()
        {
            var superheroes = await _context.Superheroes.ToListAsync();
            Superheroes.Clear();
            foreach (var superhero in superheroes)
            {
                Superheroes.Add(superhero);
            }
        }

        private async void AddSuperhero_Click(object sender, RoutedEventArgs e)
        {
            var superheroName = NameTextBox.Text;
            var superheroAlias = AliasTextBox.Text;
            var superheroPower = SuperpowerTextBox.Text;
            var selectedPowerLevel = (PowerLevel)Enum.Parse(typeof(PowerLevel), ((ComboBoxItem)PowerLevelComboBox.SelectedItem)?.Tag.ToString());
            var superheroSuperpowers = SuperpowersTextBox.Text;
            byte[] photoBytes = null;

            if (HeroImage.Source is BitmapImage bitmapImage)
            {
                photoBytes = ConvertImageToByteArray(bitmapImage);
            }

            if (!string.IsNullOrEmpty(superheroName) && !string.IsNullOrEmpty(superheroPower) && !string.IsNullOrEmpty(superheroAlias) && photoBytes != null)
            {
                var superhero = new Superhero
                {
                    Name = superheroName,
                    Alias = superheroAlias,
                    PowerLevel = selectedPowerLevel,
                    Superpowers = superheroSuperpowers.Split(',').Select(sp => new Superpower { Name = sp.Trim() }).ToList(),
                    Photo = photoBytes
                };

                Superheroes.Add(superhero);
                await SaveSuperheroToDatabase(superhero);

                NameTextBox.Clear();
                AliasTextBox.Clear();
                SuperpowerTextBox.Clear();
                SuperpowersTextBox.Clear();
                HeroImage.Source = null;
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }
        
        private void FinishEditing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTextBox != null && AliasTextBox != null && SuperpowerTextBox != null)
                {
                    MessageBox.Show("Editing finished.");
                }
                else
                {
                    MessageBox.Show("Some required fields are missing.");
                }

             FinishEditingButton.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        
        private async Task SaveSuperheroToDatabase(Superhero superhero)
        {
            _context.Superheroes.Add(superhero);
            await _context.SaveChangesAsync();
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            var superheroId = (Guid)((Button)sender).Tag;

            var superhero = Superheroes.FirstOrDefault(s => s.Id == superheroId);

            if (superhero != null)
            {
                var detailsWindow = new SuperheroDetailsWindow(superhero);
                detailsWindow.ShowDialog();
            }
        }

        private void ChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                HeroImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private byte[] ConvertImageToByteArray(BitmapImage bitmapImage)
        {
            using (var memoryStream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private void EditSuperhero_Click(object sender, RoutedEventArgs e)
        {
            var superheroId = (Guid)((Button)sender).Tag;
            
            var superhero = Superheroes.FirstOrDefault(s => s.Id == superheroId);

            if (superhero != null)
            {
                NameTextBox.Text = superhero.Name;
                AliasTextBox.Text = superhero.Alias;
                SuperpowerTextBox.Text = superhero.Superpowers.FirstOrDefault()?.Name; 
                PowerLevelComboBox.SelectedItem = PowerLevelComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Tag.ToString() == superhero.PowerLevel.ToString());
                SuperpowersTextBox.Text = string.Join(", ", superhero.Superpowers.Select(sp => sp.Name));

                if (superhero.Photo != null && superhero.Photo.Length > 0)
                {
                   using (var memoryStream = new MemoryStream(superhero.Photo))
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                        HeroImage.Source = bitmapImage;
                    }
                }

                FinishEditingButton.Visibility = Visibility.Visible;
            }
        }




        private async void DeleteSuperhero_Click(object sender, RoutedEventArgs e)
        {
            var superheroId = (Guid)((Button)sender).Tag;

            var superhero = Superheroes.FirstOrDefault(s => s.Id == superheroId);

            if (superhero != null)
            {
                Superheroes.Remove(superhero);

                _context.Superheroes.Remove(superhero);
                await _context.SaveChangesAsync();
            }
        }
    }
}
