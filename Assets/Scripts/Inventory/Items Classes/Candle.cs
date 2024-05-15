using System;
using BanishSystem;
using GameStates;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Candle : Item
    {
        private Animator _animator;
        private Player _player;
        private ItemEnum _itemEnum;

        public override ItemEnum Enum
        {
            get => _itemEnum;
            set { }
        }


        [SerializeField] private Sprite itemIcon;
        private static readonly int InteractCandle = Animator.StringToHash("InteractCandle");
        private static readonly int LastHorizontal = Animator.StringToHash("LastHorizontal");
        private static readonly int LastVertical = Animator.StringToHash("LastVertical");

        public override Sprite ItemIcon
        {
            get => itemIcon;
            set { }
        }

        private void Awake()
        {
            IsDropable = true;
            _itemEnum = ItemEnum.Candle;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.CandleInteractCompleted += CompleteAction;
        }

        public override void DoAction()
        {
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            _animator.SetTrigger(InteractCandle);
            InteractionSoundScript.Instance.ItemSounds[_itemEnum].Play();
        }

        private void CompleteAction()
        {
            _animator.SetFloat(LastVertical, -1);
            _animator.SetFloat(LastHorizontal, 0);
            WasInteracted?.Invoke(CollectInfo());
            DropItem();
            GameStateMachine.Instance.StateTransition(null);
        }

        public override event Action<BanishStep> WasInteracted;
    }
}