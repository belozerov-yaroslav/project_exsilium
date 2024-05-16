using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Icon : Item
    {
        [SerializeField] private Sprite itemIcon;

        public override Sprite ItemIcon
        {
            get => itemIcon;
            set { }
        }

        private void Awake()
        {
            IsDropable = false;
            ItemEnum = ItemEnum.Icon;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.IconInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractIcon");
        }

        protected override void ReportCompleted()
        {
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}
