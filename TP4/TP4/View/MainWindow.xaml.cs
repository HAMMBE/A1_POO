using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP4.ViewModel;

namespace TP4.View
{
    /// <summary>
    /// Logique d'interaction pour Window.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Vaisseau SelectedVaisseau { get; set; }
        private List<Vaisseau> vaisseaux = new List<Vaisseau>();
        public MainWindow()
        {
            InitializeComponent();
            SpaceInvaders jeu = new SpaceInvaders();
            vaisseaux.Add(jeu.joueur1.vaisseau);
            vaisseaux.AddRange(jeu.ennemies);
            listJoueur.ItemsSource = vaisseaux;
            listJoueurApparence.ItemsSource = vaisseaux;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";

            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                WeaponImporter.ImportWeapon(path, SelectedVaisseau.armurerieVaisseau);
                updateListArme();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ComboBox_SelectionMainChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listJoueur.SelectedIndex;
            if (index == -1)
            {
                SelectedVaisseau = null;
                uploadFile.Content = "Selectionner un vaisseau avant!";
                uploadFile.IsEnabled = false;
                removeButton.Content = "Selectionner un vaisseau avant!";
                removeButton.IsEnabled = false;
                return;
            }
            SelectedVaisseau = vaisseaux[index];
            uploadFile.Content = $"Téléverser un fichier texte \nAfin d'ajouter une arme pour le vaisseau: {SelectedVaisseau.nom}";
            uploadFile.IsEnabled = true;
            removeButton.Content = "remove Weapon";
            removeButton.IsEnabled = true;
            updateListArme();
        }
        private void ComboBox_SelectionApparenceChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listJoueurApparence.SelectedIndex;

            if (index == -1)
            {
                SelectedVaisseau = null;
                uploadFileApparence.Content = "Selectionner un vaisseau avant!";
                uploadFileApparence.IsEnabled = false;
                return;
            }
            SelectedVaisseau = vaisseaux[index];
            uploadFileApparence.Content = $"Téléverser un fichier texte \nAfin d'ajouter une image pour le vaisseau: {SelectedVaisseau.nom}";
            uploadFileApparence.IsEnabled = true;

            string path = vaisseaux[index].imagePath;
            updateImage(path);
        }

        private void uploadFileApparence_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".png";

            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                if (openFileDialog.CheckPathExists && openFileDialog.CheckFileExists)
                {
                    vaisseaux[listJoueurApparence.SelectedIndex].imagePath = path;
                    updateImage(path);
                }
            }     
        }

        private void updateImage(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                ImageVaisseau.Source = null;
                return;
            }

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path);
            image.EndInit();

            ImageVaisseau.Source = image;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = listArme.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            SelectedVaisseau.armurerieVaisseau.Armes.RemoveAt(index);
            updateListArme();
        }

        private void updateListArme()
        {
            listArme.ItemsSource = SelectedVaisseau.armurerieVaisseau.Armes;
            listArme.Items.Refresh();
        }
    }
}
