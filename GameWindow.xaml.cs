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
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Threading;

    public static class ObservableCollectionExtensions
    {
        private static readonly Random _random = new Random();

        public static void Shuffle<T>(this ObservableCollection<T> collection)
        {
            int n = collection.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = collection[k];
                collection[k] = collection[n];
                collection[n] = value;
            }
        }
    }

    public static class ListExtensions
    {
        private static readonly Random _random = new Random();

        public static void ListShuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }



    public partial class GameWindow : Window
    {
        User actualGameUser;
        int rowCount;
        int columnCount;

        ObservableCollection<BitmapImage> gameImages = new ObservableCollection<BitmapImage>
        {
            new BitmapImage(new Uri(@"/gameIcons/BobaGameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/C3p0GameImage.png", UriKind.Relative)),
            new BitmapImage(new Uri(@"/gameIcons/ChewiwGameImage.png", UriKind.Relative)),
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
        DispatcherTimer gameTime = new DispatcherTimer();
        int timer;

        public GameWindow(User actualGameUser,int level = 1, int rowCount = 6, int columnCount = 6)
        {
            InitializeComponent();
            timer = 300;
            TimerTextBlock.Text = "You have " + timer +" seconds left";
            this.actualGameUser = actualGameUser;
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.level = level;
            gameTime.Interval = TimeSpan.FromSeconds(1);
            gameTime.Tick += TimeDecrease;
            gameTime.Start();
            setText1();
            CreateGameMatrix(rowCount, columnCount);
        }
        

        private void TimeDecrease(object sender, EventArgs e)
        {
            timer--;
            TimerTextBlock.Text = $"You have {timer} seconds left";
            if(timer == 0)
            {
                gameTime.Stop();
                MessageBox.Show("You lost!", "", MessageBoxButton.OK);
            }
        }

        private void CreateGameMatrix(int n_row, int m_col)
        {
            clickCounter = 0;
            gameImages.Shuffle();
            ObservableCollection<BitmapImage> randomisedImages = new ObservableCollection<BitmapImage>(gameImages.Take(n_row * m_col /2 ));
            gridList = randomisedImages.Concat(randomisedImages).ToList();
            gridList.ListShuffle();
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            for(int it = 0; it < n_row + m_col; it++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition(){ Height = new GridLength(1,GridUnitType.Auto) });
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            }

           GameGrid.HorizontalAlignment = HorizontalAlignment.Center;
           GameGrid.VerticalAlignment = VerticalAlignment.Center;

            for(int rows = 0; rows < n_row; rows++)
            {
                for(int cols = 0; cols < m_col; cols++)
                {
                    Button button = new Button();
                    button.Click += new RoutedEventHandler(ImageButtonClick);

                    button.Width = 50;
                    button.Height = 50;

                    Grid.SetRow(button, rows);
                    Grid.SetColumn(button, cols);

                    GameGrid.Children.Add(button);
                }
            }
        }

        private bool _isFirstTile = true;
        private Tuple<Button, string> _firstButton;
        private Tuple<Button, string> _secondButton;
        private int clickCounter;
        private int level;
        
        private void setText1()
        {
            LevelTextBlock.Text = "Level 1";
        }

        private void setText2()
        {
            LevelTextBlock.Text = "Level 2";
        }

        private void setText3()
        {
            LevelTextBlock.Text = "Level 3";
        }

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

            else if(button != _firstButton.Item1)
            {
                _secondButton = new Tuple<Button, string>(button, buttonImage.Source.ToString());

                if(_firstButton.Item2 != null && _secondButton.Item2 != null)
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

            if(clickCounter == gridList.Count)
            {
                if(level == 3)
                {
                    
                    await Task.Delay(500);
                    gameTime.Stop();
                    MessageBox.Show("Congrats,you won !", "", MessageBoxButton.OK);
                    
                }
                if(level == 2)
                {
                    setText3();
                    await Task.Delay(500);
                    CreateGameMatrix(6, 6);
                    level = 3;
                }
                if(level == 1)
                {
                    setText2();
                    await Task.Delay(500);
                    CreateGameMatrix(6, 6);
                    level = 2;
                }
            }
        }
        
    }
}
