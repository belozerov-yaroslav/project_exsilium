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

        [SerializeField] private Transform dropPlace;
        [SerializeField] private GameObject objectPrefab;
        public abstract void DoAction();
        
        protected BanishStep CollectInfo()
        {
            return new BanishStep(Enum, PlayerInteraction.instance.GetNearItems(), Inventory.Instance.GetItemsOnMap());
        }

        protected void DropItem()
        {
            if (objectPrefab == null) return;
            var obj = Instantiate(objectPrefab, dropPlace.position, dropPlace.rotation);
            obj.GetComponent<ItemInteraction>().item = this;
            obj.SetActive(true);
        }

        public abstract event Action<BanishStep> WasInteracted;
    }
}