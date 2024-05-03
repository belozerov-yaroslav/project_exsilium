using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Chalk : Item
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
            set { }
        }

        private void Awake()
        {
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
            _itemEnum = ItemEnum.Chalk;
        }

        public override void DoAction()
        {
            Debug.Log("МЕЛ");
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}