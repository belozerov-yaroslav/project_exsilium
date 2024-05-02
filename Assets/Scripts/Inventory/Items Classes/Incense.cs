using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Incense : Item
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

        private void Start()
        {
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
            _itemEnum = ItemEnum.Incense;
        }
        
        public override void DoAction()
        {
            Debug.Log("БЛАГОВОНИЯ");
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}
