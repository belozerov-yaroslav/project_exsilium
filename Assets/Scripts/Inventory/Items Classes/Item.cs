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
        public bool IsDropable { get; protected set; }

        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject objectPrefab;
        public abstract void DoAction();

        //TODO Сделать чтобы он проверял какие предметы на самом деле рядом
        protected BanishStep CollectInfo()
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
                });
        }

        protected void DropItem()
        {
            if (objectPrefab == null) return;
            var obj = Instantiate(objectPrefab, playerTransform.position, playerTransform.rotation);
            obj.GetComponent<ItemInteraction>().item = this;
            obj.SetActive(true);
        }

        public abstract event Action<BanishStep> WasInteracted;
    }
}