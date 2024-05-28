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
            },
            {
                2, new[]
                {
                    new BanishStep(ItemEnum.Incense, Array.Empty<ItemEnum>(), Array.Empty<ItemEnum>()),
                    new BanishStep(ItemEnum.PrayerBook, Array.Empty<ItemEnum>(), new[] { ItemEnum.Incense }, 70f,
                        PrayEnum.PrayAgainstDemonsMachinations),
                    new BanishStep(ItemEnum.Crucifix, Array.Empty<ItemEnum>(), new[] { ItemEnum.Incense }),
                }
            },
            {
                3, new[]
                {
                    new BanishStep(ItemEnum.Chalk, Array.Empty<ItemEnum>(), Array.Empty<ItemEnum>(), 1f),
                    new BanishStep(ItemEnum.Knife, new[] { ItemEnum.Chalk }, Array.Empty<ItemEnum>()),
                    new BanishStep(ItemEnum.Candle, new[] { ItemEnum.Chalk }, Array.Empty<ItemEnum>())
                }
            },
            {
                4, new[]
                {
                    new BanishStep(ItemEnum.Herbs, Array.Empty<ItemEnum>(), new[] { ItemEnum.Herbs }),
                    new BanishStep(ItemEnum.Icon, Array.Empty<ItemEnum>(), new[] { ItemEnum.Herbs }),
                    new BanishStep(ItemEnum.PrayerBook, Array.Empty<ItemEnum>(), new[] { ItemEnum.Herbs }, 
                        70f, PrayEnum.PrayAgainstDemonsMachinations)
                }
            }
        };

        public static BanishStep[] BuildSteps(int index)
        {
            return BanishSteps.TryGetValue(index, out var value) ? value : Array.Empty<BanishStep>();
        }
    }
}