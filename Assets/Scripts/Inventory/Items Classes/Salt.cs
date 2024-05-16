using System;
using BanishSystem;
using GameStates;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Salt : Item
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
            ItemEnum = ItemEnum.Salt;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.SaltInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractSalt");
        }

        protected override void ReportCompleted()
        {
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}