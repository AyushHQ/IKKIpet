using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IKKIpet.Services
{
    public class SpriteAtlas
    {
        private readonly BitmapImage _image;

        public SpriteAtlas(string resourcePath)
        {
            _image = new BitmapImage(
                new Uri(
                    resourcePath,
                    UriKind.Absolute));
        }

        public BitmapSource GetFrame(
            Int32Rect rectangle)
        {
            var frame = new CroppedBitmap(
                _image,
                rectangle);

            frame.Freeze();

            return frame;
        }
    }
}