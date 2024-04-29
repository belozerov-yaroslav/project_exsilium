using System;
using System.Collections.Generic;
using Inventory.Items_Classes;

namespace BanishSystem
{
    public static class BanishStepsCompiler
    {
        //TODO переделать первый уровень когда будет возможность
        private static readonly Dictionary<int, BanishStep[]> BanishSteps = new()
            { { 1, new []
            {
                new BanishStep(ItemEnum.Knife, new [] {ItemEnum.Candle})
            } } };

        public static BanishStep[] BuildSteps(int index)
        {
            return BanishSteps.TryGetValue(index, out var value) ? value : Array.Empty<BanishStep>();
        }
    }
}