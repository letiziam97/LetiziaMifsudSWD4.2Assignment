using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab; // obs that will spawn
    [SerializeField] GameObject pathprefab; //path the obs will go 
    [SerializeField] float timeSpawn = 1f; //time between each spawn
    [SerializeField] float spawnRandFac = 0.3f; //random time difference for spawns
    [SerializeField] int numObs = 5; //num of obs in the wave
    [SerializeField] float obsMoveSpeed = 2f; //speed of obs

    //Encapsulation = encapsulate the variable and give excess as i deam fit - Portect variable via methods 
    public GameObject GetObsPrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWayPts() //getting the list of way points not that the prefabs
    {
        var waveWayPts = new List<Transform>();

        //access pathprefb and for each child(waypt) add it to the list waveWaypts
        foreach(Transform waypt in pathprefab.transform)
        {
            waveWayPts.Add(waypt);
        }

        return waveWayPts;
    }

    public float GetTimeSpawn()
    {
        return timeSpawn;
    }

    public float GetSpawnRandFac()
    {
        return spawnRandFac;
    }

    public float GetnumObs()
    {
        return numObs;
    }

    public float GetobsMoveSpeed()
    {
        return obsMoveSpeed;
    }

    void Start()
    {
        GetObsPrefab();
    }

}
