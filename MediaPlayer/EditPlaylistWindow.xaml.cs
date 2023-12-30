using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyMediaPlayer
{
    /// <summary>
    /// Interaction logic for EditPlaylistWindow.xaml
    /// </summary>
    public partial class EditPlaylistWindow : Window
    {
        public Playlist editedPlaylist;
        public EditPlaylistWindow(Playlist p)
        {
            InitializeComponent();
            editedPlaylist = (Playlist)p.Clone();
            DataContext = editedPlaylist;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            SendMessage(wih.Handle, 161, 2, 0);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.Title = "Please select an image file.";
            if (openFileDialog.ShowDialog() == true)
            {
                // copy image to assets folder and set image path to edittingBook

                string sourcePath = openFileDialog.FileName;
                string destinationPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Images\\{openFileDialog.SafeFileName}";

                if (!System.IO.File.Exists(destinationPath))
                {
                    System.IO.File.Copy(sourcePath, destinationPath, true);
                }



                editedPlaylist.ThumbnailPath = $"Images\\{openFileDialog.SafeFileName}";
            }
        }
    }
}
