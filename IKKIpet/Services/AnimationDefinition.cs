using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace IKKIpet.Services
{
    public class AnimationDefinition
    {
        public List<Int32Rect> Frames { get; init; } = new();

        public double FramesPerSecond { get; init; } = 8;

        public bool Loop { get; init; } = true;
    }
}
