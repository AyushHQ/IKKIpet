using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace IKKIpet.Models
{
    public class AnimationDefinition
    {
        public List<Int32Rect> Frames { get; init; } = new();

        public double FramesPerSecond { get; init; } = 8;

        public bool Loop { get; init; } = true;

        public static AnimationDefinition FromGrid(
            int row,
            int startColumn,
            int frameCount,
            int frameWidth,
            int frameHeight,
            double framesPerSecond = 8,
            bool loop = true)
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
                FramesPerSecond = framesPerSecond,
                Loop = loop
            };
        }
    }
}
