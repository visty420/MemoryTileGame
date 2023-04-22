using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MemoryTilesGame
{
    public partial class IntermediaryWindow : Window
    {
        User actualUser;
        int profilePicIndex;
        ObservableCollection<BitmapImage> profilePictures = new ObservableCollection<BitmapImage>
        {
            new BitmapImage(new Uri(@"/profilePictureItems/EmperorPalpatine.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/IncineratorStormtrooper.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/JangoFett.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/Jawa.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/Leia.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/Sandtrooper.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/ShockTrooper.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/profilePictureItems/Yoda.jpg", UriKind.Relative))
        };
        public IntermediaryWindow(User actualUser, int profilePicIndex)
        {
            InitializeComponent();
            this.actualUser = actualUser;
            this.profilePicIndex = profilePicIndex;
            actualUserTextBlock.Text = actualUser.UserNameBinding;
            actualUserProfilePicImage.Source = profilePictures[actualUser.ImageNumber];
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        private void newGameButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User actualUser = this.actualUser;
            GameWindow gameWindow = new GameWindow(actualUser);
            gameWindow.Show();
        }

        private void customGameButton_Click(object sender, RoutedEventArgs e)
        {
            CustomGameWindow customGameWindow = new CustomGameWindow(actualUser);
            this.Hide();
            customGameWindow.Show();
        }
    }
}
