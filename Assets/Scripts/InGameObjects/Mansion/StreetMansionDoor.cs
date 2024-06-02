using System.Collections;
using System.Collections.Generic;
using GameStates;
using UnityEngine;

public class StreetMansionDoor : MonoBehaviour, IInteraction
{
    public void Interact()
    {
        GameStateMachine.Instance.StateTransition(PlayerFreezeState.Instance);
        AmbientScript.Instance.StopAmbient();
        SaveSystem.SaveSceneState("Level6");
        LevelLoader.Instance.LoadLevelWithLoadingScreen("Level6");
        InteractionSoundScript.Instance.openDoorSound.Play();
    }
}
