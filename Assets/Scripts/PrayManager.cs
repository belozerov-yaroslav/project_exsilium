using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using UnityEngine;
using UnityEngine.UI;

public class PrayManager : MonoBehaviour
{
    [SerializeField] public GameObject path;

    public WayPoint wayPoint;
    public TargetCircle targetCircle;
    public AppearanceScript appearanceScript;
    
    private static Dictionary<PrayEnum, float> _velocityDict = new Dictionary<PrayEnum, float>
    {
        {PrayEnum.PrayHolySpirit,0.005f},
        {PrayEnum.PrayAgainstDemonsMachinations,0.01f},
        {PrayEnum.PrayArchangelMichael , 0.015f}
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

    public void SetWaypoint() => wayPoint.moveVelocity = _velocityDict[targetCircle.pray];

    public void StartCircle()
    {
        SetWaypoint();
        targetCircle.StartAim();
    }
    
}
