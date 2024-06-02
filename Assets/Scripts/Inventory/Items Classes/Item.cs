using System;
using System.Collections.Generic;
using BanishSystem;
using GameStates;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory.Items_Classes
{
    public abstract class Item : MonoBehaviour
    {
        protected Animator _animator;
        protected Player _player;
        protected int Id;
        public ItemEnum ItemEnum { get; protected set; }
        private static readonly int LastHorizontal = Animator.StringToHash("LastHorizontal");
        private static readonly int LastVertical = Animator.StringToHash("LastVertical");
        public abstract Sprite ItemIcon { get; set; }
        public bool IsDropable { get; protected set; }

        [SerializeField] private Transform dropPlace;
        [SerializeField] private GameObject objectPrefab;

        public static readonly Dictionary<ItemEnum, string> EnumToName = new()
        {
            { ItemEnum.Candle, "Свеча" },
            { ItemEnum.Knife, "Нож" },
            { ItemEnum.Crucifix, "Распятие" },
            { ItemEnum.Chalk, "Мел" },
            { ItemEnum.Incense, "Благовония" },
            { ItemEnum.Herbs, "Травы" },
            { ItemEnum.PrayerBook, "Молитвенник" },
            { ItemEnum.Icon, "Икона" },
            { ItemEnum.Salt, "Соль" }
        };

        public virtual void DoAction()
        {
            GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
            _animator.SetTrigger(Id); 
            _animator.SetFloat(LastVertical, -1);
            _animator.SetFloat(LastHorizontal, 0);
            InteractionSoundScript.Instance.ItemSounds[ItemEnum].Play();
        }
        
        protected virtual BanishStep CollectInfo()
        {
            return new BanishStep(ItemEnum, PlayerInteraction.Instance.GetNearItems(), Inventory.Instance.GetItemsOnMap());
        }

        protected abstract void ReportCompleted();

        protected virtual void DropItem()
        {
            if (objectPrefab == null) return;
            var obj = Instantiate(objectPrefab, dropPlace.position, dropPlace.rotation);
            obj.GetComponent<ItemInteraction>().item = this;
            obj.SetActive(true);
            DropEffect(obj);
        }

        protected virtual void DropEffect(GameObject gameObject)
        {
            
        }
        protected void CompleteAction()
        {
            ReportCompleted();
            GameStateMachine.Instance.StateTransition(null);
        }

        public abstract event Action<BanishStep> WasInteracted;
    }
}