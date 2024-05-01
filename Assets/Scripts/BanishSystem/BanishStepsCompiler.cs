using System;
using System.Collections.Generic;
using Inventory.Items_Classes;

namespace BanishSystem
{
    public static class BanishStepsCompiler
    {
        private static readonly Dictionary<int, BanishStep[]> BanishSteps = new()
        {
            {
                1, new[]
                {
                    new BanishStep(ItemEnum.Candle, Array.Empty<ItemEnum>(), Array.Empty<ItemEnum>()),
                    new BanishStep(ItemEnum.Salt, new[] { ItemEnum.Candle }, new[] { ItemEnum.Candle }),
                    new BanishStep(ItemEnum.PrayerBook, Array.Empty<ItemEnum>(), new[] { ItemEnum.Candle }, 70f,
                        PrayEnum.PrayArchangelMichael)
                }
            }
        };
        private static readonly Dictionary<int, BanishStep[]> CrushingFactors = new()
        {
            {
                1, new[]
                {
                    new BanishStep(ItemEnum.Chalk, Array.Empty<ItemEnum>(), Array.Empty<ItemEnum>(), 0f)
                }
            }
        };

        public static BanishStep[] BuildSteps(int index)
        {
            return BanishSteps.TryGetValue(index, out var value) ? value : Array.Empty<BanishStep>();
        }
        
        public static BanishStep[] BuildFactors(int index)
        {
            return CrushingFactors.TryGetValue(index, out var value) ? value : Array.Empty<BanishStep>();
        }
    }
}