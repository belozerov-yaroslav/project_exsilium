using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Candle : Item
    {
        private ItemEnum _itemEnum;
        public override ItemEnum Enum
        {
            get => _itemEnum;
            set {}
        }

        private Sprite _itemIcon;

        public override Sprite ItemIcon
        {
            get => _itemIcon;
            set{}
        }

        private void Awake()
        {
            IsDropable = true;
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
            _itemEnum = ItemEnum.Candle;
        }
        
        public override void DoAction()
        {
            Debug.Log("СВЕЧА");
            WasInteracted?.Invoke(CollectInfo());
            DropItem();
        }

        public override event Action<BanishStep> WasInteracted;
    }
}
