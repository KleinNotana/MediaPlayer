using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Configuration;
using System.ComponentModel;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media.Animation;


namespace MyMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<Playlist> playlists;

        MediaFile currentFile = null;

        //MediaPlayer mediaPlayer = new MediaPlayer();

        bool isPlaying = false;
        bool isShuffle = false;
        bool isRepeat = false;
        bool isDraggingTimeSlider = false;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            playlists = JsonHelper.LoadFromJson<Playlist>("playlists.json");

            listPlaylists.ItemsSource = playlists;

            Player.MediaEnded += (s, e) =>
            {
                mediaPlayerEnded();
            };
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            SendMessage(wih.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            /*var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["LastView"].Value

            config.Save(ConfigurationSaveMode.Minimal);

            ConfigurationManager.RefreshSection("appSettings");*/
            JsonHelper.SaveToJson(playlists, "playlists.json");
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnAddPlaylist_Click(object sender, RoutedEventArgs e)
        {
             Playlist playlist = new Playlist();
            playlist.Name = "My Playlist";
            playlist.Files = new BindingList<MediaFile>();
            playlists.Add(playlist);
        }

        private void listPlaylists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var playlist = listPlaylists.SelectedItem as Playlist;

            if (playlist != null)
            {
                this.DataContext = playlist;
            }
            

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void listSongs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectFile();
        }

        private void btnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                var playlist = listPlaylists.SelectedItem as Playlist;

                if (playlist != null)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        playlist.Files.Add(new MediaFile() { Path = file });
                    }
                }

            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile != null)
            {
                if(isPlaying)
                {
                    Player.Pause();
                    iconPlay.Icon = FontAwesome.Sharp.IconChar.Play;
                    iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Play;
                    isPlaying = false;
                }
                else
                {
                    Player.Play();
                    iconPlay.Icon = FontAwesome.Sharp.IconChar.Pause;
                    iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Pause;
                    isPlaying = true;
                }
            }
        }

        private void btnShuffle_Click(object sender, RoutedEventArgs e)
        {
            if (isShuffle)
            {
                var color = (SolidColorBrush)Application.Current.Resources["plainTextColor1"];
                isShuffle = false;
                iconShuffle.Foreground = color;
            }
            else
            {
                isShuffle = true;
                iconShuffle.Foreground = Brushes.Red;
                shufflePlaylist();
            }
        }

        void shufflePlaylist()
        {
            var playlist = listSongs.ItemsSource as BindingList<MediaFile>;
            if (playlist != null)
            {
                Random random = new Random();
                int n = playlist.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    // Hoán đổi các phần tử ở vị trí k và n
                    var temp = playlist[k];
                    playlist[k] = playlist[n];
                    playlist[n] = temp;
                }
            }
            
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = listSongs.SelectedIndex;
            if (selectedIndex > 0)
            {
                listSongs.SelectedIndex = selectedIndex - 1;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = listSongs.SelectedIndex;
            if (selectedIndex < listSongs.Items.Count - 1)
            {
                listSongs.SelectedIndex = selectedIndex + 1;
            }
        }

        private void btnRepeat_Click(object sender, RoutedEventArgs e)
        {
            if (isRepeat)
            {
                var color = (SolidColorBrush)Application.Current.Resources["plainTextColor1"];
                isRepeat = false;
                iconRepeat.Foreground = color;
            }
            else
            {
                isRepeat = true;
                iconRepeat.Foreground = Brushes.Red;
            }

        }

        private void selectFile()
        {
            var selectedFile = listSongs.SelectedItem as MediaFile;

            if (selectedFile != null)
            {
                currentFile = selectedFile;

                //Player.Open(new Uri(selectedFile.Path));
                Player.Source = new Uri(selectedFile.Path);
                
                Player.MediaOpened += (s, e) =>
                {
                    Timer timer = new Timer() { CurrentTime = Player.Position, TotalTime = Player.NaturalDuration.TimeSpan };
                    timeControlBar.DataContext = timer;
                };

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, e) =>
                {
                    Timer timer = timeControlBar.DataContext as Timer;
                    if (timer != null)
                    {
                        timer.CurrentTime = Player.Position;
                    }
                };
                timer.Start();

                Player.Play();
                iconPlay.Icon = FontAwesome.Sharp.IconChar.Pause;
                iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Pause;
                isPlaying = true;
                filePlayer.DataContext = selectedFile;

                //create a new object include current time and max time of mediaPlayer
                Preview.Source = new Uri(currentFile.Path);

            }
        }


        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Player.NaturalDuration.HasTimeSpan && !isDraggingTimeSlider)
            {
                Player.Position = TimeSpan.FromSeconds(slider.Value);
            }
        }


        private void timeControlBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDraggingTimeSlider = true;
        }

        private void timeControlBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDraggingTimeSlider = false;
        }

        private void mediaPlayerEnded()
        {
            if (isRepeat)
            {
               Player.Position = TimeSpan.Zero;
               Player.Play();
            }
            else
            {
                var selectedIndex = listSongs.SelectedIndex;
                if (selectedIndex < listSongs.Items.Count - 1)
                {
                    listSongs.SelectedIndex = selectedIndex + 1;
                }
            }
        }

        //display preview when seek time slider
        private void slider_MouseEnter(object sender, MouseEventArgs e)
        {   
            
            var slider = sender as Slider;
            
            var position = e.GetPosition(slider);
            var value = position.X / slider.ActualWidth * slider.Maximum;
            var time = TimeSpan.FromSeconds(value);
            var timeString = time.ToString(@"mm\:ss");
            
            
            
            Preview.Position = time;
            Preview.Play();
            //wait for 0.1 second
            System.Threading.Thread.Sleep(100);
            Preview.Pause();
            
        }

        //mouse move on seek time slider
        private void slider_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            var slider = sender as Slider;
            
            var position = e.GetPosition(slider);
            var value = position.X / slider.ActualWidth * slider.Maximum;
            var time = TimeSpan.FromSeconds(value);
            var timeString = time.ToString(@"mm\:ss");



            Preview.Position = time;
            Preview.Play();
            //change volume
            Preview.Volume = 0;
            //wait for 0.1 second
            System.Threading.Thread.Sleep(100);
            Preview.Pause();
        }

        
    }


    
}