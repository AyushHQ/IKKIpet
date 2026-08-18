using System.Collections.Generic;
using System.Windows;

namespace IKKIpet.Models
{
    public class AnimationDefinition
    {
        public List<Int32Rect> Frames { get; init; } = new();

        public double FramesPerSecond { get; init; } = 8;

        public bool Loop { get; init; } = true;

        // Frame range in which the next combo input is accepted.
        // -1 means this animation has no combo window.
        public int ComboWindowStart { get; init; } = -1;

        public int ComboWindowEnd { get; init; } = -1;

        public bool IsComboWindowOpen(int frameIndex)
        {
            if (ComboWindowStart < 0 ||
                ComboWindowEnd < 0)
            {
                return false;
            }

            return frameIndex >= ComboWindowStart &&
                   frameIndex <= ComboWindowEnd;
        }

        public static AnimationDefinition FromGrid(
            int row,
            int startColumn,
            int frameCount,
            int frameWidth,
            int frameHeight,
            double framesPerSecond = 8,
            bool loop = true,
            int comboWindowStart = -1,
            int comboWindowEnd = -1)
        {
            var frames = new List<Int32Rect>();

            for (int i = 0; i < frameCount; i++)
            {
                int column = startColumn + i;

                frames.Add(
                    new Int32Rect(
                        column * frameWidth,
                        row * frameHeight,
                        frameWidth,
                        frameHeight));
            }

            return new AnimationDefinition
            {
                Frames = frames,

                FramesPerSecond =
                    framesPerSecond,

                Loop =
                    loop,

                ComboWindowStart =
                    comboWindowStart,

                ComboWindowEnd =
                    comboWindowEnd
            };
        }
    }
}