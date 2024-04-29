using System;
using BanishSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory.Items_Classes
{
    public abstract class Item : MonoBehaviour
    {
        public abstract ItemEnum Enum { get; set; }
        public abstract Sprite ItemIcon { get; set; }
        public abstract void DoAction();

        //TODO Сделать чтобы он проверял какие предметы на самом деле рядом
        protected BanishStep CollectInfo()
        {
            return new BanishStep(Enum,
                new[]
                {
                    ItemEnum.Candle, ItemEnum.Chalk, ItemEnum.Crucifix, ItemEnum.Herbs, ItemEnum.Icon, ItemEnum.Incense,
                    ItemEnum.Knife, ItemEnum.PrayerBook
                });
        }

        public abstract event Action<BanishStep> WasInteracted;
    }
}