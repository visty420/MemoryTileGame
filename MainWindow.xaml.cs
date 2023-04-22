using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace MemoryTilesGame
{
    public partial class MainWindow : Window
    {
        ObservableCollection<User> Users { get; set; }
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

        public void UpdateUserList(ObservableCollection<User> updatedUserList)
        {
            Users = updatedUserList;
            PlayerListView.ItemsSource = Users;
        }

        public MainWindow()
        {   
           InitializeComponent();
          /* if(!File.Exists("UserData.xml"))
            {
                CreateUserXml();
            } */
           LoadXml loadXml = new LoadXml();
            Users = loadXml.LoadUsersFromXml("@UserData.xml");
            deleteUserButton.IsEnabled = false;
            playButton.IsEnabled = false;
            PlayerListView.ItemsSource = Users;
        }


        private void PlayerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayerListView.SelectedItem != null)
            {
                deleteUserButton.IsEnabled = true;
                playButton.IsEnabled = true;
                User user = (User)PlayerListView.SelectedItem;
                userProfilePicture.Source = profilePictures[user.ImageNumber];
            }
        }

        private void newUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewUserWindow newWindow = new NewUserWindow(Users, profilePictures);
            newWindow.Show();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void previousUserButton_Click(object sender, RoutedEventArgs e)
        {
            int index = PlayerListView.SelectedIndex;
            if (index > 0)
            {
                PlayerListView.SelectedIndex = index - 1;
            }
        }

        private void nextUserButton_Click(object sender, RoutedEventArgs e)
        {
            int index = PlayerListView.SelectedIndex;
            if (index < PlayerListView.Items.Count - 1)
            {
                PlayerListView.SelectedIndex = index + 1;
            }
        }

        public void CreateUserXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(root);
            xmlDoc.Save("@UserData.xml");
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("@UserData.xml");
            XmlNode root = xmlDoc.DocumentElement;

            string userNameDeletion = ((User)PlayerListView.SelectedItem).UserNameBinding;
            XmlNode item = root.SelectSingleNode("//User[userName='" + userNameDeletion + "']");
            item.ParentNode.RemoveChild(item);
            xmlDoc.Save("@UserData.xml");
            this.UpdateUserList(Users);
            LoadXml loadXml = new LoadXml();
            Users = loadXml.LoadUsersFromXml("@UserData.xml");
            PlayerListView.ItemsSource = Users;
        }

        private void playButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User selectedUser = (User)PlayerListView.SelectedItem;
            int picIndex = selectedUser.ImageNumber;
            IntermediaryWindow newWindow = new IntermediaryWindow(selectedUser, picIndex);
            newWindow.Show();
        }
    }
}
