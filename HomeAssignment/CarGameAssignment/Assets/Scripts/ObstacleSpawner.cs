using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of waveConfig
    [SerializeField] List<WaveConfig> waveConList;

    //controls the looping of the waves
    [SerializeField] bool looping = false;
    

    IEnumerator Start()
    {
        do
        {
            //start of coroutine that spawns all obs in currWave
            yield return StartCoroutine(SpawnWavesAll());
        }
        while (looping); //while true

    }

    //Co-routine - being specific to spawn all enemies in waves
    private IEnumerator SpawnAllObsInWave(WaveConfig waveToSpawn)
    {
        //in order to spawn all obs in a wave 
        for (int obsCount = 1; obsCount <= waveToSpawn.GetnumObs(); obsCount++)
        {
            //spawn the obs from waveConfig at the position specified by waveconfig waypts.
            var newObs = Instantiate(waveToSpawn.GetObsPrefab(), waveToSpawn.GetWayPts()[0].transform.position, Quaternion.identity);

            //obs will be applied to this wave.
            newObs.GetComponent<ObstaclesPathing>().SetWaveCon(waveToSpawn);
            
            //wait for time between spawns before spawning another obstacles.
            yield return new WaitForSeconds(waveToSpawn.GetTimeSpawn());
        }
    }
    
    private IEnumerator SpawnWavesAll()
    {
        //looping
        foreach(WaveConfig curwave in waveConList)
        {
            //wait for all the obstacles to spawn before going to the next wave
            yield return StartCoroutine(SpawnAllObsInWave(curwave));
        }
    }
}
