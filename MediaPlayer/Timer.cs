using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediaPlayer
{
    public class Timer: INotifyPropertyChanged
    {
        public TimeSpan CurrentTime { get; set;}
        public TimeSpan TotalTime { get; set;}

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
