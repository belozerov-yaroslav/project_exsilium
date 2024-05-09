using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using UnityEngine;
using UnityEngine.UI;

public class PrayManager : MonoBehaviour
{
    [SerializeField] public GameObject path;
    public Canvas PrayGameCanvas;

    public WayPoint wayPoint;
    public TargetCircle targetCircle;
    
    private static Dictionary<PrayEnum, float> _velocityDict = new Dictionary<PrayEnum, float>
    {
        {PrayEnum.PrayHolySpirit,0.005f},
        {PrayEnum.PrayAgainstDemonsMachinations,0.01f},
        {PrayEnum.PrayArchangelMichael , 0.015f},
        {PrayEnum.PrayFairCross, 0.012f}
    };

    public void FirstButtonAction()
    {
        targetCircle.pray = PrayEnum.PrayHolySpirit;
        StartCircle();
    }
    
    public void SecondButtonAction()
    {
        targetCircle.pray =  PrayEnum.PrayAgainstDemonsMachinations;
        StartCircle();
    }
    
    public void ThirdButtonAction()
    {
        targetCircle.pray = PrayEnum.PrayArchangelMichael;
        StartCircle();
    }

    public void FourthButtonAction()
    {
        targetCircle.pray = PrayEnum.PrayFairCross;
        StartCircle();
    }

    public void SetWaypoint() => wayPoint.moveVelocity = _velocityDict[targetCircle.pray];

    public void StartCircle()
    {
        PrayGameCanvas.enabled = true;
        SetWaypoint();
        targetCircle.StartAim();
    }
    
}
