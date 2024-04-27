using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Knife : Item
    {
        private int _itemId;
        public override int ItemId
        {
            get => _itemId;
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
            _itemId = 1;
        }
        
        public override void DoAction()
        {
            Debug.Log("Н О Ж");
        }
    }
}
