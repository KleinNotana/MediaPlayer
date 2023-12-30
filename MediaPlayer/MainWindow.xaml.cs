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
        bool isStart = true;

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


            if (ConfigurationManager.AppSettings["currentPlaylist"] != null)
            {
                listPlaylists.SelectedIndex = int.Parse(ConfigurationManager.AppSettings["currentPlaylist"]);
            }

            if (ConfigurationManager.AppSettings["currentFile"] != null)
            {
                listSongs.SelectedIndex = int.Parse(ConfigurationManager.AppSettings["currentFile"]);

            }

            Player.MediaOpened += (s, e) =>
            {
                if (isStart && ConfigurationManager.AppSettings["currentPosition"] != null)
                {
                    Player.Position = TimeSpan.Parse(ConfigurationManager.AppSettings["currentPosition"]);

                    if (isPlaying)
                    {
                        Player.Pause();
                        iconPlay.Icon = FontAwesome.Sharp.IconChar.Play;
                        iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Play;
                        isPlaying = false;
                    }

                    isStart = false;
                }
            };

            if (ConfigurationManager.AppSettings["currentVolume"] != null)
            {
                sliderVolume.Value = double.Parse(ConfigurationManager.AppSettings["currentVolume"]);
            }
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
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["currentPlaylist"].Value = listPlaylists.SelectedIndex.ToString();
            config.AppSettings.Settings["currentVolume"].Value = sliderVolume.Value.ToString();
            config.AppSettings.Settings["currentFile"].Value = listSongs.SelectedIndex.ToString();
            config.AppSettings.Settings["currentPosition"].Value = Player.Position.ToString();


            config.Save(ConfigurationSaveMode.Minimal);

            ConfigurationManager.RefreshSection("appSettings");
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

            if (playlist != null )
            {
                this.DataContext = playlist;
            }


        }

        private void listSongs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Mouse.RightButton == MouseButtonState.Released)
            {
                // Xử lý sự kiện chỉ khi không phải là chuột phải
                selectFile();
            }
        }

        private void btnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            //filer sound and video files
            openFileDialog.Filter = "Media files (*.mp3, *.mp4, *.wav, *.avi, *.mkv) | *.mp3; *.mp4; *.wav; *.avi; *.mkv";

            if (openFileDialog.ShowDialog() == true)
            {
                var playlist = listPlaylists.SelectedItem as Playlist;

                if (playlist != null)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        if(!playlist.Files.Any(f => f.Path == file))
                        {
                            playlist.Files.Add(new MediaFile() { Path = file });
                        }
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
                var extension = System.IO.Path.GetExtension(selectedFile.Path);

                if (extension == ".mp4" || extension == ".avi" || extension == ".mkv")
                {
                    Player.Visibility = Visibility.Visible;
                    Preview.Visibility = Visibility.Visible;
                }
                else
                {
                    Player.Visibility = Visibility.Collapsed;
                    Preview.Visibility = Visibility.Collapsed;
                }

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

                if (isStart)
                {
                    Player.Volume = 0;
                }

                Player.Play();
                iconPlay.Icon = FontAwesome.Sharp.IconChar.Pause;
                iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Pause;
                isPlaying = true;

                

                filePlayer.DataContext = selectedFile;

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
                else
                {
                    Player.Pause();
                    iconPlay.Icon = FontAwesome.Sharp.IconChar.Play;
                    iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Play;
                    isPlaying = false;

                }
            }
        }

        //display preview when seek time slider
        private void slider_MouseEnter(object sender, MouseEventArgs e)
        {   
            Preview.Visibility = Visibility.Visible;
            
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var playlist = listPlaylists.SelectedItem as Playlist;
            if (playlist != null)
            {
                EditPlaylistWindow editPlaylistWindow = new EditPlaylistWindow(playlist);

                if (editPlaylistWindow.ShowDialog() == true)
                {
                    var updatedPlaylist = editPlaylistWindow.editedPlaylist;
                    updatedPlaylist.CopyProperties(playlist);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var playlist = listPlaylists.SelectedItem as Playlist;

            if(isPlaying && playlist.Files.Contains(currentFile))
            {
                Player.Stop();
                currentFile = null;
                filePlayer.DataContext = null;
                iconPlay.Icon = FontAwesome.Sharp.IconChar.Play;
                iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Play;
                isPlaying = false;

                Player.Visibility = Visibility.Collapsed;
                Preview.Visibility = Visibility.Collapsed;
            }

            if (playlist != null)
            {
                playlists.Remove(playlist);
            }

            if(playlists.Count > 0)
            {
                listPlaylists.SelectedIndex = 0;
            }



            
        }

        private void btnEditPlaylist_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.ContextMenu.IsEnabled = true;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            button.ContextMenu.IsOpen = true;
        }

        private void btnDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            var playlist = listPlaylists.SelectedItem as Playlist;
            var selectedFile = listSongs.SelectedItem as MediaFile;


            if (playlist != null && selectedFile != null)
            {
                //check current file is selected

                if (isPlaying && currentFile == selectedFile)
                {
                    Player.Stop();
                    currentFile = null;
                    filePlayer.DataContext = null;
                    iconPlay.Icon = FontAwesome.Sharp.IconChar.Play;
                    iconPlayPause.Icon = FontAwesome.Sharp.IconChar.Play;
                    isPlaying = false;

                    Player.Visibility = Visibility.Collapsed;
                    Preview.Visibility = Visibility.Collapsed;
                }

                playlist.Files.Remove(selectedFile);
            }
        }

        private void btnPlayPlaylist_Click(object sender, RoutedEventArgs e)
        {
            listSongs.SelectedIndex = 0;

            currentFile = listSongs.SelectedItem as MediaFile;

            if (currentFile != null)
            {
                if (isPlaying)
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

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Volume = sliderVolume.Value / 100;
        }

        private void slider_MouseLeave(object sender, MouseEventArgs e)
        {
            Preview.Visibility = Visibility.Hidden;
        }

        private void slider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDraggingTimeSlider = true;
        }

        private void slider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDraggingTimeSlider = false;
        }

        private void slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (!isDraggingTimeSlider)
            {
                Player.Position = TimeSpan.FromSeconds(slider.Value);
            }
        }
    }


    
}