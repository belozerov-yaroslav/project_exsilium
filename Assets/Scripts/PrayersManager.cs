using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayersManager : MonoBehaviour
{
    public WayPoint toWayPointScrypt;
    public GameObject path;

    public void LoadPath()
    {
        toWayPointScrypt.path = path;
        toWayPointScrypt.GetWayPoints();
    }

 
}
