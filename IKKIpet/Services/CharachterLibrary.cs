using IKKIpet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.TextFormatting;

namespace IKKIpet.Services
{
    public static class CharachterLibrary
    {
        private const int FrameWidth = 288;
        private const int FrameHeight = 128;
        private static readonly Dictionary<CharachterId, CharachterDefinition> _charachters = new()
        {
            [CharachterId.WindWarrior] = CreateWindWarrior()
        };

        public static CharachterDefinition Get(CharachterId charachter)
        {
            return _charachters[charachter];
        }

        //-------------------------------------------------------------WindWarrior---------------------------------------------------------------------

        private static CharachterDefinition CreateWindWarrior()
        {
            return new CharachterDefinition
            {
                Id = CharachterId.WindWarrior,

                Name = "Khaleed",

                SpriteSheetPath =
                    "/Assets/WindWarrior/Khaleed_288x128.png",

                Animations = new Dictionary<AnimationId, AnimationDefinition>
                {
                    // Row 0
                    [AnimationId.Idle] =
                        AnimationDefinition.FromGrid(
                            row: 0,
                            startColumn: 0,
                            frameCount: 8,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 8,
                            loop: true),

                    // Row 1
                    [AnimationId.Run] =
                        AnimationDefinition.FromGrid(
                            row: 1,
                            startColumn: 0,
                            frameCount: 8,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 10,
                            loop: true),

                    // Row 2
                    [AnimationId.JumpUp] =
                        AnimationDefinition.FromGrid(
                            row: 2,
                            startColumn: 0,
                            frameCount: 3,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 8,
                            loop: false),

                    // Row 3
                    [AnimationId.JumpDown] =
                        AnimationDefinition.FromGrid(
                            row: 3,
                            startColumn: 0,
                            frameCount: 3,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 8,
                            loop: false),

                    // Row 4
                    [AnimationId.AirAttack] =
                        AnimationDefinition.FromGrid(
                            row: 4,
                            startColumn: 0,
                            frameCount: 7,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 5
                    [AnimationId.Roll] =
                        AnimationDefinition.FromGrid(
                            row: 5,
                            startColumn: 0,
                            frameCount: 6,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 6
                    [AnimationId.Attack1] =
                        AnimationDefinition.FromGrid(
                            row: 6,
                            startColumn: 0,
                            frameCount: 8,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 7
                    [AnimationId.Attack2] =
                        AnimationDefinition.FromGrid(
                            row: 7,
                            startColumn: 0,
                            frameCount: 18,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 8
                    [AnimationId.Attack3] =
                        AnimationDefinition.FromGrid(
                            row: 8,
                            startColumn: 0,
                            frameCount: 26,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 9
                    [AnimationId.SpecialAttack] =
                        AnimationDefinition.FromGrid(
                            row: 9,
                            startColumn: 0,
                            frameCount: 30,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 10
                    [AnimationId.Defend] =
                        AnimationDefinition.FromGrid(
                            row: 10,
                            startColumn: 0,
                            frameCount: 8,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 8,
                            loop: true),

                    // Row 11
                    [AnimationId.TakeHit] =
                        AnimationDefinition.FromGrid(
                            row: 11,
                            startColumn: 0,
                            frameCount: 6,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 12,
                            loop: false),

                    // Row 12
                    [AnimationId.Death] =
                        AnimationDefinition.FromGrid(
                            row: 12,
                            startColumn: 0,
                            frameCount: 19,
                            frameWidth: FrameWidth,
                            frameHeight: FrameHeight,
                            framesPerSecond: 10,
                            loop: false)
                },

                //Abilities = new List<AbilityId>
                //{
                //    AbilityId.BasicAttack,
                //    AbilityId.HeavyAttack,
                //    AbilityId.SpecialAttack,
                //    AbilityId.Dash,
                //    AbilityId.Block
                //}
            };
        }
    }
}