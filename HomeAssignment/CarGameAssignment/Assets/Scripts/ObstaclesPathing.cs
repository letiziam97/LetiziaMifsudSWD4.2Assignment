using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPathing : MonoBehaviour
{
    [SerializeField] List<Transform> obsWaypoints;
    [SerializeField] float obsMoveSpeed = 2f;

    int waypointIndex = 0 ; //saves the waypoint direction

    void Start()
    {
        //setting the start position for obstacle
        transform.position = obsWaypoints[waypointIndex].transform.position;

    }


    void Update()
    {
        
    }
}
    