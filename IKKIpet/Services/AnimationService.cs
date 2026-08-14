using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace IKKIpet.Services
{
    class AnimationService
    {
        private readonly Image _image;
        private readonly List<BitmapImage> _frames = new();

        private readonly DispatcherTimer _timer;

        private int _currentFrame = 0;

        public AnimationService(Image image)
        {
            _image = image;
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(125),
            };
            _timer.Tick += OnTimerTick;
            LoadIdleFrames();
        }

        private void LoadIdleFrames()
        {
            for (int i = 1; i <= 8; i++)
            {
                var uri = new Uri(
                    $"pack://application:,,,/Assets/Dragon/Idle/idle_{i:00}.png",
                    UriKind.Absolute);

                _frames.Add(new BitmapImage(uri));
            }
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            _image.Source = _frames[_currentFrame];

            _currentFrame++;

            if (_currentFrame >= _frames.Count)
            {
                _currentFrame = 0;
            }
        }

        public void Play()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

    }
}
