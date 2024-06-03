using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class PrayerBook : Item
    {
        [SerializeField] private Sprite itemIcon;
        public Canvas prayCanvas;
        private PrayEnum _pray;
        private float _percentageCorrectness;
        
        private Sprite _itemIcon;

        public override Sprite ItemIcon
        {
            get => _itemIcon;
            set { }
        }

        private void Awake()
        {
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
            ItemEnum = ItemEnum.PrayerBook;
            TargetCircle.OnFinished += GetPrayResults;
        }
        private void Start()
        {
            _animator = Player.Instance.GetComponent<Animator>();
            _player = Player.Instance.GetComponent<Player>();
        }

        private void GetPrayResults(float percent, PrayEnum pray)
        {
            _pray = pray;
            _percentageCorrectness = percent;
            WasInteracted?.Invoke(CollectInfo());
        }

        public override void DoAction()
        {
            GameStateMachine.Instance.StateTransition(PrayerBookState.Instance); 
        }

        protected override BanishStep CollectInfo()
        {
            return new BanishStep(ItemEnum, PlayerInteraction.instance.GetNearItems(), Inventory.Instance.GetItemsOnMap(), 
                _percentageCorrectness, _pray);
        }

        protected override void ReportCompleted()
        {
            throw new NotImplementedException();
        }

        public override event Action<BanishStep> WasInteracted;
    }
}