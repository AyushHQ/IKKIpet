using IKKIpet.Models;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;

namespace IKKIpet.Services
{
    public class CharachterController
    {
        private readonly Image _image;
        private readonly SpriteAnimation _animation;

        private CharachterDefinition? _charachter;

        private AnimationId? _currentAnimation;

        private bool _comboQueued;

        public event Action? AnimationCompleted;

        public CharachterController(Image image)
        {
            _image = image;

            _animation = new SpriteAnimation();

            _animation.FrameChanged += OnFrameChanged;
            _animation.AnimationCompleted += OnAnimationCompleted;
        }

        public void SetCharacter(CharachterId charachterId)
        {
            _charachter =
                CharachterLibrary.Get(charachterId);

            _animation.LoadSpriteSheet(
                _charachter.SpriteSheetPath);

            _currentAnimation = null;
            _comboQueued = false;
        }

        public void Play(AnimationId animationId)
        {
            if (_charachter == null)
                return;

            if (!_charachter.Animations.TryGetValue(
                    animationId,
                    out AnimationDefinition? animation))
            {
                return;
            }

            _currentAnimation = animationId;

            _animation.Play(animation);
        }

        public void Attack()
        {
            if (_charachter == null)
                return;

            switch (_currentAnimation)
            {
                case AnimationId.Attack1:
                case AnimationId.Attack2:

                    if (IsComboWindowOpen())
                    {
                        _comboQueued = true;
                    }
                    break;

                case AnimationId.Attack3:
                    break;

                default:

                    Play(AnimationId.Attack1);

                    break;
            }
        }

        public void Stop()
        {
            _animation.Stop();
        }

        private void OnFrameChanged(
            BitmapSource frame)
        {
            _image.Source = frame;
        }

        private bool IsComboWindowOpen()
        {
            if (_charachter == null)
                return false;

            if (_currentAnimation == null)
                return false;

            if (!_charachter.Animations.TryGetValue(
                    _currentAnimation.Value,
                    out AnimationDefinition? animation))
            {
                return false;
            }

            return animation.IsComboWindowOpen(
                _animation.CurrentFrame);
        }

        private void OnAnimationCompleted()
        {
            AnimationCompleted?.Invoke();

            if (_charachter == null)
                return;

            switch (_currentAnimation)
            {
                case AnimationId.Attack1:

                    if (_comboQueued)
                    {
                        _comboQueued = false;

                        Play(AnimationId.Attack2);
                    }
                    else
                    {
                        Play(AnimationId.Idle);
                    }

                    break;

                case AnimationId.Attack2:

                    if (_comboQueued)
                    {
                        _comboQueued = false;

                        Play(AnimationId.Attack3);
                    }
                    else
                    {
                        Play(AnimationId.Idle);
                    }

                    break;

                case AnimationId.Attack3:

                    _comboQueued = false;

                    Play(AnimationId.Idle);

                    break;

                default:

                    Play(AnimationId.Idle);

                    break;
            }
        }
    }
}