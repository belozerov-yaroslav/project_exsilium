using UnityEngine;
using System;

public abstract class Quest : MonoBehaviour
{
   public abstract bool IsFinished { get; protected set; }

   public abstract void UpdateQuest();
}
