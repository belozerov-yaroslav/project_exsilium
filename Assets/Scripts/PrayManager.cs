using System;
using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using GameStates;
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
        {PrayEnum.PrayHolySpirit,0.05f},
        {PrayEnum.PrayAgainstDemonsMachinations,0.03f},
        {PrayEnum.PrayArchangelMichael , 0.05f},
        {PrayEnum.PrayFairCross, 0.04f}
    };

    private Dictionary<PrayEnum, AudioSource> praySounds = new Dictionary<PrayEnum, AudioSource>();

    [SerializeField] private AudioSource firstPraySound;
    [SerializeField] private AudioSource secondPraySound;
    [SerializeField] private AudioSource thirdPraySound;
    [SerializeField] private AudioSource fourthPraySound;

    private void Start()
    {
        praySounds = new Dictionary<PrayEnum, AudioSource>
        {
            {PrayEnum.PrayHolySpirit,firstPraySound},
            {PrayEnum.PrayAgainstDemonsMachinations,secondPraySound},
            {PrayEnum.PrayArchangelMichael , thirdPraySound},
            {PrayEnum.PrayFairCross, fourthPraySound}
        };
        
    }

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
        PrayerBookState.IsBlocked = true;
        PrayGameCanvas.enabled = true;
        SetWaypoint();
        targetCircle.praySound = praySounds[targetCircle.pray];
        targetCircle.StartAim();
    }
    
}
