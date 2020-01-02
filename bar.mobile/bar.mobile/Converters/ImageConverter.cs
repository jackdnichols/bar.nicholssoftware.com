using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;

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
                /*
                    Image image = new Image();
                    Stream stream = new MemoryStream(byteArray);
                    image.Source = ImageSource.FromStream(stream);
                */
                Uri uri = new Uri(value.ToString());
                ImageSource imgSource = UriImageSource.FromUri(uri);
                return imgSource;
                //return ImageSource.FromUri(new Uri(value.ToString(), UriKind.RelativeOrAbsolute));
                //return GetImageStreamFromURL(value.ToString());
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

        private async Task<Xamarin.Forms.Image> GetImageStreamFromURL(String imageUrl)
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Stream stream = await client.GetStreamAsync(imageUrl);

            Xamarin.Forms.Image img = new Xamarin.Forms.Image();
            img.Source = ImageSource.FromStream(() => stream);

            return img;
        }
    }
}
