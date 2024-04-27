using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory.Items_Classes
{
    public abstract class Item : MonoBehaviour
    {

        public abstract int ItemId { get; set; }
        public abstract Sprite ItemIcon { get; set; }
        public abstract void DoAction();
    }
}
