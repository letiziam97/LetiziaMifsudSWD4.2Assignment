using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPathing : MonoBehaviour
{
    [SerializeField] List<Transform> obsWaypoints;
    [SerializeField] float ObsmoveSpeed = 2f;

    [SerializeField] WaveConfig waveconf;


    int waypointIndex = 0 ; //saves the waypoint direction

    void Start()
    {
        //getting the list of obswaypoints from waveconf
        obsWaypoints = waveconf.GetWayPts();

        //setting the start position for obstacle
        transform.position = obsWaypoints[waypointIndex].transform.position;
    }


    void Update()
    {
        ObsMove();
    }


    private void ObsMove()
    {
        if (waypointIndex <= obsWaypoints.Count - 1)
        {
            //setting the TargetPosition where we the obstacle wants to go.
            var tarPos = obsWaypoints[waypointIndex].transform.position;

            //z-axis = 0
            tarPos.z = 0f;

            //moving the obtacle through way points
            var obsMovem = ObsmoveSpeed * Time.deltaTime;

            //moving towards the way points
            transform.position = Vector2.MoveTowards(transform.position, tarPos, obsMovem);

            //when target waypoint is reached
            if (transform.position == tarPos)

            {
                waypointIndex++;
            }
            //last waypoint is reached
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
    