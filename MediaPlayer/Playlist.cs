using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer
{
    public class Playlist : INotifyPropertyChanged, ICloneable
    {
        private BindingList<MediaFile> files;

        public Playlist()
        {
            ThumbnailPath = "Images/thumbnail.png";
            // Khởi tạo BindingList
            Files = new BindingList<MediaFile>();
            // Gắn sự kiện ListChanged cho BindingList để theo dõi sự thay đổi trong danh sách
            Files.ListChanged += Files_ListChanged;
        }

        public string Name { get; set; }

        public BindingList<MediaFile> Files
        {
            get { return files; }
            set
            {
                if (files != value)
                {
                    files = value;
                    OnPropertyChanged(nameof(Files));
                }
            }
        }

        public int NumberOfFiles
        {
            get { return Files.Count; }
        }

        public string ThumbnailPath { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Files_ListChanged(object sender, ListChangedEventArgs e)
        {
            // Khi có sự thay đổi trong Files, cập nhật NumberOfFiles
            OnPropertyChanged(nameof(NumberOfFiles));
        }
    }
}
