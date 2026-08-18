using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using IKKIpet.Models;

namespace IKKIpet.Services
{
    public class SpriteAnimation
    {
        private readonly DispatcherTimer _timer;

        private BitmapSource? _spriteSheet;

        private AnimationDefinition? _currentAnimation;

        private int _currentFrame;

        public int CurrentFrame => _currentFrame;

        public event Action<BitmapSource>? FrameChanged;

        public event Action? AnimationCompleted;

        public SpriteAnimation()
        {
            _timer = new DispatcherTimer();

            _timer.Tick += OnTimerTick;
        }

        public void LoadSpriteSheet(string resourcePath)
        {
            var resourceUri = new Uri(
                resourcePath,
                UriKind.Relative);

            var resource = Application.GetResourceStream(resourceUri);

            if (resource == null)
            {
                throw new InvalidOperationException(
                    $"Could not find WPF resource: {resourcePath}");
            }

            using (resource.Stream)
            {
                var bitmap = new BitmapImage();

                bitmap.BeginInit();

                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = resource.Stream;

                bitmap.EndInit();
                bitmap.Freeze();

                _spriteSheet = bitmap;
            }
        }

        public void Play(AnimationDefinition animation)
        {
            if (_spriteSheet == null)
                return;

            if (animation.Frames.Count == 0)
                return;

            Stop();

            _currentAnimation = animation;

            _currentFrame = 0;

            _timer.Interval = TimeSpan.FromSeconds(
                1.0 / animation.FramesPerSecond);

            ShowCurrentFrame();

            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void OnTimerTick(
            object? sender,
            EventArgs e)
        {
            if (_currentAnimation == null)
                return;

            _currentFrame++;

            if (_currentFrame >=
                _currentAnimation.Frames.Count)
            {
                if (_currentAnimation.Loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    _currentFrame =
                        _currentAnimation.Frames.Count - 1;

                    Stop();
                    AnimationCompleted?.Invoke();
                }
            }

            ShowCurrentFrame();
        }

        private void ShowCurrentFrame()
        {
            if (_spriteSheet == null)
                return;

            if (_currentAnimation == null)
                return;

            if (_currentFrame < 0 ||
                _currentFrame >=
                _currentAnimation.Frames.Count)
            {
                return;
            }

            Int32Rect rectangle =
                _currentAnimation.Frames[_currentFrame];

            var frame = new CroppedBitmap(
                _spriteSheet,
                rectangle);

            frame.Freeze();

            FrameChanged?.Invoke(frame);
        }
    }
}