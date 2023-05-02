using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Blackjack.Views
{
    public class CardToBrushConverter : IMultiValueConverter
    {
        static Dictionary<string, Brush> brs = new Dictionary<string, Brush>();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return null;

            string suit = (string) values[0];
            string face = (string) values[1];
            bool fd = (bool) values[2];

            string imgString = string.Empty;

            if (fd)
            {
                imgString = "backOfCard";
            }
            else
            {
                imgString = face + "_of_" + suit;
            }

            imgString = "pack://application:,,,/Resource/IMG/" + imgString + ".png";

            if (brs.ContainsKey(imgString) == false)
                brs.Add(imgString, new ImageBrush(new BitmapImage(new Uri(imgString))));

            return brs[imgString];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
