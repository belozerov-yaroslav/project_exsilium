using System;
using BanishSystem;
using GameStates;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Candle : Item
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
            ItemEnum = ItemEnum.Candle;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.CandleInteractCompleted += CompleteAction;
            Id = Animator.StringToHash("InteractCandle");
        }

        protected override void ReportCompleted()
        {
            DropItem();
            WasInteracted?.Invoke(CollectInfo());
        }

        protected override void DropEffect(GameObject obj)
        {
            ExtinguishedScript.PlacedCandle = obj;
            BlueCandleScript.PlacedCandle = obj;
        }


        public override event Action<BanishStep> WasInteracted;
    }
}