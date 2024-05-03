using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public TargetCircle targetCircle;
    [SerializeField] public GameObject path;

    [SerializeField] public float minVelocity;
    [SerializeField]public float maxVelocity;
    [SerializeField]public float moveVelocity;
    [SerializeField] public float timeDelay;
    
    private Transform[] _waypoints;
    private bool _isStarted = false;
    private int _waypointIndex = 0;
    private float _timeLeft;
    
    private void Start()
    {
        timeDelay = targetCircle.timeDelay;
    }

    public void GetWayPoints()
    {
        _waypoints = new Transform[path.transform.childCount];
        for (var i = 0; i < path.transform.childCount; i++)
        {
            _waypoints[i] = path.transform.GetChild(i);
        }

        _waypoints[0] = transform;
        StartWay();
    }
    
    private void Update()
    {
        if(!_isStarted) return;
        Move();
    }

    public void StartWay()
    {
        _isStarted = true;
        targetCircle.StartAim();
    }

    public void StopWay()
    {
        _isStarted = false;
        _waypointIndex = 0;
    }


    private void Move()
    {
        var target = _waypoints[_waypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position,
            target, moveVelocity * Random.Range(minVelocity,maxVelocity) );
        if (transform.position == target)
            _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;
    }
}
