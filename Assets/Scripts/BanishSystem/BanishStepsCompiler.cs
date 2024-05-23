﻿using System;
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
            }
        };

        public static BanishStep[] BuildSteps(int index)
        {
            return BanishSteps.TryGetValue(index, out var value) ? value : Array.Empty<BanishStep>();
        }
    }
}