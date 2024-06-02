using System;
using System.Collections;
using System.Collections.Generic;
using BanishSystem;
using GameStates;
using UnityEngine;
using UnityEngine.UI;

public class PrayManager : MonoBehaviour
{
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

    [SerializeField] private GameObject path1;
    [SerializeField] private GameObject path2;
    [SerializeField] private GameObject path3;
    [SerializeField] private GameObject path4;

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
        wayPoint.path = path1;
        StartCircle();
    }
    
    public void SecondButtonAction()
    {
        wayPoint.path = path2;
        targetCircle.pray =  PrayEnum.PrayAgainstDemonsMachinations;
        StartCircle();
    }
    
    public void ThirdButtonAction()
    {
        wayPoint.path = path3;
        targetCircle.pray = PrayEnum.PrayArchangelMichael;
        StartCircle();
    }

    public void FourthButtonAction()
    {
        wayPoint.path = path4;
        targetCircle.pray = PrayEnum.PrayFairCross;
        StartCircle();
    }

    public void StartCircle()
    {
        wayPoint.FillWaypoints();
        PrayerBookState.IsBlocked = true;
        PrayGameCanvas.enabled = true;
        wayPoint.moveVelocity = _velocityDict[targetCircle.pray];
        targetCircle.praySound = praySounds[targetCircle.pray];
        targetCircle.StartAim();
    }
    
}
