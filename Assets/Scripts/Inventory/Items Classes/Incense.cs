using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Incense : Item
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
            ItemEnum = ItemEnum.Incense;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.IncenseInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractIncense");
        }

        protected override void ReportCompleted()
        {
            DropItem();
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}
