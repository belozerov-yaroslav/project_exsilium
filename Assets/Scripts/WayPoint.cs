using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public GameObject path;
    
    [SerializeField] public float minVelocity;
    [SerializeField]public float maxVelocity;
    [SerializeField]public float moveVelocity;
    
    private Transform[] _waypoints;
    private int _waypointIndex = 0;
    
    public bool IsStarted { get; set; }
    
    private void Start()
    {
        _waypoints = new Transform[path.transform.childCount];
        for (var i = 0; i < path.transform.childCount; i++)
        {
            _waypoints[i] = path.transform.GetChild(i);
        }

        _waypoints[0] = transform;

    }
    
    private void Update()
    {
        if(!IsStarted) return;
        Move();
    }
    
    
    public void StopWay()
    {
        IsStarted = false;
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
