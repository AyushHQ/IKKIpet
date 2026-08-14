using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace IKKIpet.Services
{
    public class SpriteAnimation
    {
        private readonly DispatcherTimer _timer;

        private BitmapImage? _spriteSheet;

        private AnimationDefinition? _currentAnimation;

        private int _currentFrame;

        public event Action<BitmapSource>? FrameChanged;

        public SpriteAnimation()
        {
            _timer = new DispatcherTimer();

            _timer.Tick += OnTimerTick;
        }

        public void LoadSpriteSheet(string resourcePath)
        {
            _spriteSheet = new BitmapImage(
                new Uri(resourcePath, UriKind.Absolute));

            _spriteSheet.Freeze();
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