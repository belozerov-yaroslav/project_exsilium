using UnityEngine;
using System;

public abstract class Quest : MonoBehaviour
{
   public abstract event Action QuestCompeted;
   public abstract void FinishQuest();
}
