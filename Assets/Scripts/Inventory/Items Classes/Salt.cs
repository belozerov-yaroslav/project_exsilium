using System;
using BanishSystem;
using GameStates;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Salt : Item
    {
        private Animator _animator;
        private Player _player;
        private ItemEnum _itemEnum;
        public override ItemEnum Enum
        {
            get => _itemEnum;
            set {}
        }

        private Sprite _itemIcon;
        private static readonly int InteractSalt = Animator.StringToHash("InteractSalt");
        private static readonly int LastHorizontal = Animator.StringToHash("LastHorizontal");
        private static readonly int LastVertical = Animator.StringToHash("LastVertical");

        public override Sprite ItemIcon
        {
            get => _itemIcon;
            set{}
        }
        private void Awake()
        {
            _itemEnum = ItemEnum.Salt;
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
        }

        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
            _player.SaltInteractCompleted += CompleteAction;
        }
        
        public override void DoAction()
        {
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            _animator.SetTrigger(InteractSalt);
            ItemSoundsScript.ItemSounds[_itemEnum].Play();
        }

        private void CompleteAction()
        {
            _animator.SetFloat(LastVertical, -1);
            _animator.SetFloat(LastHorizontal, 0);
            WasInteracted?.Invoke(CollectInfo());
            GameStateMachine.Instance.StateTransition(null);
        }

        public override event Action<BanishStep> WasInteracted;
    }
}