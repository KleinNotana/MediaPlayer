using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer
{
    public class Playlist : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public BindingList<MediaFile> Files { get; set; }
        public int NumberOfFiles { get { return Files.Count; } }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
