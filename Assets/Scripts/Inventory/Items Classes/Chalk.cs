using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class Chalk : Item
    {

        [SerializeField] private Sprite itemIcon;
        private float _percentageCorrectness;

        public override Sprite ItemIcon
        {
            get => itemIcon;
            set { }
        }

        public void GetQteResult(bool isSuccess)
        {
            _percentageCorrectness = isSuccess ? 1f : 0f;
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
            PentagrammController.Instance.pentagram.ChalkInteractCompleted += CompleteAction;
            PentagrammController.Instance.QteFinished += GetQteResult;
            Id = Animator.StringToHash("InteractChalk");
        }
        
        public override void DoAction()
        {
            GameStateMachine.Instance.StateTransition(PentagrammState.Instance);
            _animator.SetTrigger(Id); 
            InteractionSoundScript.Instance.ItemSounds[ItemEnum].Play();
        }
        
        protected override BanishStep CollectInfo()
        {
            return new BanishStep(ItemEnum, PlayerInteraction.instance.GetNearItems(), Inventory.Instance.GetItemsOnMap(), 
                _percentageCorrectness);
        }

        protected override void ReportCompleted()
        {
            if(_percentageCorrectness > 1e-5)
                DropItem();
            WasInteracted?.Invoke(CollectInfo());
        }

        public override event Action<BanishStep> WasInteracted;
    }
}