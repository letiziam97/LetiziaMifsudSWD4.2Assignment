using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of waveConfig
    [SerializeField] List<WaveConfig> waveConList;

    //Wave 0 
    int startWave = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //currentwave = wave1 that is position 0 in list
        var currWave = waveConList[startWave];

        //start of coroutine that spawns all obs in currWave
        StartCoroutine(SpawnAllObsInWave(currWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Co-routine - being specific which wave is needed to spawn
    private IEnumerator SpawnAllObsInWave(WaveConfig waveConfig)
    {
        //spawn the obs from waveConfig at the position specified by waveconfig waypts.
        Instantiate(waveConfig.GetObsPrefab(), waveConfig.GetWayPts()[0].transform.position, Quaternion.identity);
        //wait for time between spawns before spawning another obstacles.
        yield return new WaitForSeconds(waveConfig.GetTimeSpawn());
    }
}
