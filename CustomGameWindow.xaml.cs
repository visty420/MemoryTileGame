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
using System.Windows.Threading;

namespace MemoryTilesGame
{
    public partial class CustomGameWindow : Window
    {
        private int clickCounter;

        public CustomGameWindow(User user, int rows=0, int cols=0, int level = 1)
        {
            InitializeComponent();
            actualGameUser = user;
            timer = 150;
            CustomGameTimer.Text = "You have " + timer + " seconds left";
            this.rows = rows;
            this.cols = cols;
            this.level = level;
            gameTime.Interval = TimeSpan.FromSeconds(1);
            gameTime.Tick += TimeDecrease;

        }
        int rows;
        int cols;
        int level;
        User actualGameUser;

        ObservableCollection<BitmapImage> gameImages = new ObservableCollection<BitmapImage>
        {
            new BitmapImage(new Uri(@"/gameIcons/BobaGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/C3p0GameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/ChewieGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/HanGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/KenobiGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/LeiaGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/LukeGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/PalpatineGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/R2D2GameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/StormtrooperGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/VaderGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/YodaGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/BattleDroidGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/CloneGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/DeathTrooperGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/JangoGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/OrderTrooperGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/ScoutTrooperGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/ShoreTrooperGameImage.jpg", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/StormCommanderGameImage.jpg", UriKind.Relative)),
        };

        List<BitmapImage> gridList;

        private void CreateGameMatrix(int n_row, int m_col)
        {
            clickCounter = 0;
            gameImages.Shuffle();
            ObservableCollection<BitmapImage> randomisedImages = new ObservableCollection<BitmapImage>(gameImages.Take(n_row * m_col / 2));
            gridList = randomisedImages.Concat(randomisedImages).ToList();
            gridList.ListShuffle();
            CustomGameGrid.Children.Clear();
            CustomGameGrid.RowDefinitions.Clear();
            CustomGameGrid.ColumnDefinitions.Clear();

            for (int it = 0; it < n_row + m_col; it++)
            {
                CustomGameGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star)});
                CustomGameGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});
            }

            CustomGameGrid.HorizontalAlignment = HorizontalAlignment.Center;
            CustomGameGrid.VerticalAlignment = VerticalAlignment.Center;

            for (int rows = 0; rows < n_row; rows++)
            {
                for (int cols = 0; cols < m_col; cols++)
                {
                    Button button = new Button();
                    button.Click += new RoutedEventHandler(ImageButtonClick);

                    button.Width = 50;
                    button.Height = 50;

                    Grid.SetRow(button, rows);
                    Grid.SetColumn(button, cols);

                    CustomGameGrid.Children.Add(button);
                }
            }
        }

        private void submitInputButton_Click(object sender, RoutedEventArgs e)
        {   
            rows = int.Parse(RowsTextBox.Text);
            cols = int.Parse(ColumnsTextBox.Text);
            columnCount = cols;
            
            if ((rows * cols) % 2 == 0)
            {
                setText1();
                CreateGameMatrix(rows, cols);
                gameTime.Start();
            }
            else
            {
                MessageBox.Show("Please introduce an even number of cards !","",MessageBoxButton.OK);
            }
            
        }

        private bool _isFirstTile = true;
        private Tuple<Button, string> _firstButton;
        private Tuple<Button, string> _secondButton;
        private int columnCount;

        private async void ImageButtonClick(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            BitmapImage image = gridList[row * columnCount + column];
            Image buttonImage = new Image();
            buttonImage.Source = image;

            button.Content = buttonImage;

            if (_isFirstTile)
            {
                _firstButton = new Tuple<Button, string>(button, buttonImage.Source.ToString());
                _isFirstTile = false;
            }

            else if (button != _firstButton.Item1)
            {
                _secondButton = new Tuple<Button, string>(button, buttonImage.Source.ToString());

                if (_firstButton.Item2 != null && _secondButton.Item2 != null)
                {
                    if (_firstButton.Item2.Equals(_secondButton.Item2) == true)
                    {
                        await Task.Delay(500);

                        _firstButton.Item1.Visibility = Visibility.Hidden;
                        _secondButton.Item1.Visibility = Visibility.Hidden;
                        clickCounter += 2;
                    }
                    else
                    {
                        await Task.Delay(500);

                        _firstButton.Item1.Content = new Image();
                        _secondButton.Item1.Content = new Image();
                    }

                    _isFirstTile = true;
                }
            }
            if (clickCounter == gridList.Count)
            {
                if (level == 3)
                {
                    await Task.Delay(500);
                    gameTime.Stop();
                    MessageBox.Show("Congrats,you won !", "", MessageBoxButton.OK);
                }
                if (level == 2)
                {
                    setText3();
                    await Task.Delay(500);
                    CreateGameMatrix(rows, cols);
                    level = 3;
                }
                if (level == 1)
                {
                    setText2();
                    await Task.Delay(500);
                    CreateGameMatrix(rows, cols);
                    level = 2;
                }
            }
        }

        private void setText1()
        {
            CustomGameBlockLevel.Text = "Level 1";
        }

        private void setText2()
        {
            CustomGameBlockLevel.Text = "Level 2";
        }

        private void setText3()
        {
            CustomGameBlockLevel.Text = "Level 3";
        }

        private int timer = 150;
        DispatcherTimer gameTime = new DispatcherTimer();
        private void TimeDecrease(object sender, EventArgs e)
        {
            timer--;
            CustomGameTimer.Text = $"You have {timer} seconds left";
            if (timer == 0)
            {
                gameTime.Stop();
                MessageBox.Show("You lost !", "", MessageBoxButton.OK);
            }
        }
    }
}
