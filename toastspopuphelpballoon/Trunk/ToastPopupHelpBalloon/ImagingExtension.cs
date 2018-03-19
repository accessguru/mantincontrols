using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace Mantin.Controls.Wpf.Notification
{
    internal static class ImagingExtension
    {
        /// <summary>
        /// To the bitmap image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        /// <summary>
        /// To the bitmap.
        /// </summary>
        /// <param name="bitmapImage">The bitmap image.</param>
        /// <returns></returns>
        public static Bitmap ToBitmap(this BitmapImage bitmapImage)
        {
            using (var memory = new MemoryStream())
            {
                var encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memory);
                var bitmap = new Bitmap(memory);

                return new Bitmap(bitmap);
            }
        }
    }
}
