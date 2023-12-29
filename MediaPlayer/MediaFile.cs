using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer
{
    public class MediaFile: INotifyPropertyChanged
    {
        public string Path { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
