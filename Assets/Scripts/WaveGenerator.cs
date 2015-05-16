using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WaveGenerator : MonoBehaviour {

    //Get all the Waves that can be spawned here
    public WaveScript[] Waves;
    //pause between the player finishing one wave and spawning the next
    public float WavePause;
    //Determines wether the WaveGenerator should be active (the game has started)
    public bool DoSpawnWaves = true;


    int livingEnemies = 0;
    public int RandomSeed;

	// Use this for initialization
	void Start () {
        RandomSeed = Random.Range(1, 10000);
        Random.seed = RandomSeed;
	}
	
	// Update is called once per frame
	void Update () {
	    if (DoSpawnWaves)
        {
            if (Input.GetKeyDown(KeyCode.P))
                SpawnWave(1);
        }
	}


    void SpawnWave (int waveLevel)
    {
        //Get a List of all the available waves that have the desired level
        List<WaveScript> randomWaves = new List<WaveScript>();

        foreach (WaveScript w in Waves)
        {
            if (w.DifficultyLevel == waveLevel)
            {
                randomWaves.Add(w);
            }
        }
        if (randomWaves.Capacity != 0)
        {
            InstantiateEnemies(randomWaves[Random.Range(0, randomWaves.Count)]);

        }
            //TBRS
        else
        {
            Debug.Log("no random waves!!");
        }
            //TBRE

    }

    void InstantiateEnemies(WaveScript wave)
    {
        /*
        Debug.Log("diff " + wave.DifficultyLevel);
        Debug.Log("number " + wave.EnemiesToSpawn[0].EnemyAmount);
        Debug.Log("name " + wave.EnemiesToSpawn[0].EnemyPrefab.name);
        Debug.Log("prio " + wave.EnemiesToSpawn[0].SpawnPriority);
        */

        //Makes a local copy of the WaveScript so we can mess with it
        WaveScript thisWave = wave;
        //sorts the WaveScript by the spawnpriority of the enemies
        thisWave.EnemiesToSpawn.Sort(SortBySpawnPriority);

        

    }

    //used to sort the enemies to be spawned by their priority value
    private static int SortBySpawnPriority(WaveScript.EnemyInfo e1, WaveScript.EnemyInfo e2)
    {
        return e1.SpawnPriority.CompareTo(e2.SpawnPriority);
    }

    public void EnemyDied()
    {

    }

     
}
