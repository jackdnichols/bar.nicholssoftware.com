using System;
using System.Globalization;
using Xamarin.Forms;

namespace bar.mobile.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(ImageSource))
            {
                throw new InvalidOperationException("Invalid target type.");
            }

            try
            {
                return new Uri("https://s3-media0.fl.yelpcdn.com/bphoto/-qYFoL7TuHTZ0PQjfREeAw/ls.jpg");
            }
            catch(Exception ex)
            {
                return null; 
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
