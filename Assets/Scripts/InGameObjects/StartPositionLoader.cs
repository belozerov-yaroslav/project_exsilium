using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class StartPosition
{
    public string sceneName;
    [FormerlySerializedAs("position")] public Transform positionTransform;
}

public class StartPositionLoader : MonoBehaviour
{
    [SerializeField] private Transform _defaultPosition;
    [SerializeField] private List<StartPosition> _startPositions;
    void Start()
    {
        var startPosition = _startPositions.FirstOrDefault(startPosition => startPosition.sceneName == RoomDoorInteraction.LastSceneName);
        if (startPosition is null)
        {
            Player.Instance.transform.position = _defaultPosition.position;
            return;
        }
        Player.Instance.transform.position = startPosition.positionTransform.position;
    }
}
