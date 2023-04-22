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
using System.Xml;

namespace MemoryTilesGame
{
    public partial class NewUserWindow : Window
    {
        ObservableCollection<User> users;
        ObservableCollection<BitmapImage> profilePictureImages { get; set; }
        int pictureIndex = 0;
        public NewUserWindow(ObservableCollection<User> Users, ObservableCollection<BitmapImage> profilePictures)
        {   
            InitializeComponent();
            users = Users;
            profilePictureImages = profilePictures;
            imageImagePicker.Source = profilePictureImages[pictureIndex];
        }

        public void UpdateAvatarList(ObservableCollection<BitmapImage> updatedList)
        {
            profilePictureImages = updatedList;
        }

        private void nextPictureButton_Click(object sender, RoutedEventArgs e)
        {
            if(pictureIndex < profilePictureImages.Count() - 1)
            {
                pictureIndex++;
                imageImagePicker.Source = profilePictureImages[pictureIndex];
            }
        }

        private void previousPictureButton_Click(object sender, RoutedEventArgs e)
        {
            if (pictureIndex > 0)
            {
                pictureIndex--;
                imageImagePicker.Source = profilePictureImages[pictureIndex];
            }
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("UserData.xml");
            bool oke = true;
            XmlNodeList userNodes = xmlDoc.SelectNodes("//User");
            foreach(XmlNode userNode in userNodes)
            {
                XmlNode userNameNode = userNode.SelectSingleNode("userName");
                if(userNameNode.InnerText == userNameTextBox.Text)
                {
                    oke = false;
                    break;
                }
            }
            if(oke)
            {
                User newUser = new User();
                newUser.UserNameBinding = userNameTextBox.Text;
                newUser.ImageNumber = pictureIndex;
                users.Add(newUser);
                AddUserToXml(newUser.UserNameBinding, pictureIndex);
                MainWindow mainWindow = new MainWindow();
                mainWindow.UpdateUserList(users);
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Username-ul exista deja.", "Error", MessageBoxButton.OK);
            }
        }

        public void AddUserToXml(string username, int imageIndex)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("@UserData.xml");

            XmlElement userElement = xmlDoc.CreateElement("User");

            XmlElement usernameElement = xmlDoc.CreateElement("userName");
            usernameElement.InnerText = username;
            userElement.AppendChild(usernameElement);

            XmlElement imageElement = xmlDoc.CreateElement("imageIndex");
            imageElement.InnerText = imageIndex.ToString();
            userElement.AppendChild(imageElement);

            XmlElement rootElement = xmlDoc.DocumentElement;
            rootElement.AppendChild(userElement);

            xmlDoc.Save("@UserData.xml");
        }
    }
}
