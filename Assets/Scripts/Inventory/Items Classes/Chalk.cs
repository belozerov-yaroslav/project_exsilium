using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Chalk : Item
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
            ItemEnum = ItemEnum.Chalk;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.ChalkInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractChalk");
        }

        protected override void ReportCompleted()
        {
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}