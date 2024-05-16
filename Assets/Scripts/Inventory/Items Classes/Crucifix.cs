using System;
using BanishSystem;
using GameStates;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Crucifix : Item
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
            ItemEnum = ItemEnum.Crucifix;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.CrucifixInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractCrucifix");
        }

        protected override void ReportCompleted()
        {
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}
