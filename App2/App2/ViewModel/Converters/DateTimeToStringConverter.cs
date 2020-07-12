using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

namespace App2.ViewModel.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset rightNow = DateTimeOffset.Now;
            var didderence = rightNow - dateTime;
            if (didderence.TotalDays >1)
            {
                return $"{dateTime:d}";
            }
            else
            {
                if (didderence.TotalSeconds < 60)
                {
                    return $"{didderence.TotalSeconds:0} seconds ago";
                }
                if (didderence.TotalMinutes < 60)
                {
                    return $"{didderence.TotalMinutes:0} minutes ago";
                }
                if (didderence.TotalHours < 24)
                {
                    return $"{didderence.TotalHours:0} hours ago";
                }

                return "yestarday";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now; 
        }
    }
}
