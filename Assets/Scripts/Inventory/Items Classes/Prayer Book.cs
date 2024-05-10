using System;
using BanishSystem;
using UnityEngine;

namespace Inventory.Items_Classes
{
    public class PrayerBook : Item
    {
        private ItemEnum _itemEnum;
        public Canvas prayCanvas;
        private PrayEnum _pray;
        private float _percentageCorrectness;
        
        public override ItemEnum Enum
        {
            get => _itemEnum;
            set { }
        }

        private Sprite _itemIcon;

        public override Sprite ItemIcon
        {
            get => _itemIcon;
            set { }
        }

        private void Awake()
        {
            _itemIcon = GetComponent<SpriteRenderer>().sprite;
            _itemEnum = ItemEnum.PrayerBook;
            TargetCircle.OnFinished += GetPrayResults;
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

        private new BanishStep CollectInfo()
        {
            return new BanishStep(Enum, PlayerInteraction.instance.GetNearItems(), Inventory.Instance.GetItemsOnMap(), 
                _percentageCorrectness, _pray);
        }

        public override event Action<BanishStep> WasInteracted;
    }
}