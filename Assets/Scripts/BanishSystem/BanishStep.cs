using System;
using System.Linq;
using Inventory.Items_Classes;
using Unity.Collections;

namespace BanishSystem
{
    public class BanishStep
    {
        private readonly ItemEnum _interactionItemEnum;
        private readonly ItemEnum[] _nearItems;
        private readonly float _percentageOfCorrectness;
        private readonly PrayEnum _pray;


        public BanishStep(ItemEnum interactionItemEnum, ItemEnum[] nearItems, float percentageOfCorrectness = 100f,
            PrayEnum pray = PrayEnum.None)
        {
            _interactionItemEnum = interactionItemEnum;
            _nearItems = nearItems;
            _percentageOfCorrectness = percentageOfCorrectness;
            _pray = pray;
        }


        public bool EquivalentTo(BanishStep obj)
        {
            return obj._interactionItemEnum != _interactionItemEnum &&
                   !(_percentageOfCorrectness - 0.1 > obj._percentageOfCorrectness) &&
                   _nearItems.All(item => obj._nearItems.Contains(item)) &&
                   (_pray == PrayEnum.None || _pray == obj._pray);
        }
    }
}