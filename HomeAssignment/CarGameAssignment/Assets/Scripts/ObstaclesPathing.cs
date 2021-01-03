using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPathing : MonoBehaviour
{
    [SerializeField] List<Transform> bikeWaypoint;
    [SerializeField] float obsMoveSpeed = 2f;

    int waypointIndex = 0; //saves the waypoint direction

    void Start()
    {
        //setting the start position for obstacle
        transform.position = bikeWaypoint[waypointIndex].transform.position;

    }


    void Update()
    {
        
    }
}
    