using UnityEngine;
using System;

public interface IQuest
{
   public void Update()
   {
   } 
   
   public bool IsFinished { get; protected set; }
}
