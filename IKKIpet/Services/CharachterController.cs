using IKKIpet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace IKKIpet.Services
{
    public class CharachterController
    {
        private readonly Image _image;
        private readonly SpriteAnimation _animation;
            
        private CharachterDefinition? _character;

        public CharachterController(Image image)
        {
            _image = image;

            _animation = new SpriteAnimation();

            _animation.FrameChanged += OnFrameChanged;
        }

        public void SetCharacter(CharachterId characterId)
        {
            _character =
                CharachterLibrary.Get(characterId);

            _animation.LoadSpriteSheet(
                _character.SpriteSheetPath);
        }

        public void Play(AnimationId animationId)
        {
            if (_character == null)
                return;

            if (!_character.Animations.TryGetValue(
                    animationId,
                    out AnimationDefinition? animation))
            {
                return;
            }

            _animation.Play(animation);
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
    }
}
