using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyMediaPlayer
{
    class PathToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (path == null)
                return null;
            string[] parts = path.Split('\\');

            var fileName = parts[parts.Length - 1];
            //eliminate the extension
            
            int lastDotIndex = fileName.LastIndexOf('.');
            if (lastDotIndex == -1)
                return fileName;
            
            return fileName.Substring(0, lastDotIndex);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
