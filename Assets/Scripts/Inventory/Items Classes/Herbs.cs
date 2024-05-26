using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Herbs : Item
    {
        [SerializeField] private Sprite itemIcon;

        public override Sprite ItemIcon
        {
            get => itemIcon;
            set { }
        }

        private void Awake()
        {
            IsDropable = true;
            ItemEnum = ItemEnum.Herbs;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.HerbsInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractHerbs");
        }

        protected override void ReportCompleted()
        {
            DropItem();
            WasInteracted?.Invoke(CollectInfo());
        }

        protected override void DropEffect(GameObject obj)
        {
            HandleBanishFinishedBedroom.PlacedHerbs = obj;
        }

        public override event Action<BanishStep> WasInteracted;
    }
}
