using IKKIpet.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.TextFormatting;

namespace IKKIpet.Models
{
    public class CharachterDefinition
    {
        public CharachterId Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string SpriteSheetPath { get; init; } = string.Empty;

        public Dictionary<AnimationId, AnimationDefinition> Animations { get; init; }
            = new();
    }
}
