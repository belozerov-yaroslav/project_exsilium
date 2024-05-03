using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class PrayerBook : Item
    {
        private ItemEnum _itemEnum;

        public override ItemEnum Enum
        {
            get => _itemEnum;
            set { }
        }

        private Sprite _itemIcon;

        public override Sprite ItemIcon
        {
            get => _itemIcon;
            set { }
        }

        private void Awake()
        {
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
            _itemEnum = ItemEnum.PrayerBook;
        }

        public override void DoAction()
        {
            Debug.Log("МОЛИТВЫ");
            WasInteracted?.Invoke(CollectInfo());
        }

        private new BanishStep CollectInfo()
        {
            return new BanishStep(Enum,
                new[]
                {
                    ItemEnum.Candle, ItemEnum.Chalk, ItemEnum.Crucifix, ItemEnum.Herbs, ItemEnum.Icon, ItemEnum.Incense,
                    ItemEnum.Knife, ItemEnum.PrayerBook
                }, new[]
                {
                    ItemEnum.Candle, ItemEnum.Chalk, ItemEnum.Crucifix, ItemEnum.Herbs, ItemEnum.Icon, ItemEnum.Incense,
                    ItemEnum.Knife, ItemEnum.PrayerBook
                }, 100f, PrayEnum.PrayArchangelMichael);
        }

        public override event Action<BanishStep> WasInteracted;
    }
}