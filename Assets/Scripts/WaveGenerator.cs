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
    //sets the Spawnpoints (will be set by the MapManager)
    public List<Transform> SpawnPoints = new List<Transform>();

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
        //used to make enemies spawn at the specified rate
        float currentSpawnTime = Time.time;
        //sorts the WaveScript by the spawnpriority of the enemies
        thisWave.EnemiesToSpawn.Sort(SortBySpawnPriority);
        //iterates through each type of enemy by their priority
        foreach (WaveScript.EnemyInfo currentEnemy in thisWave.EnemiesToSpawn)
        {
            //used so the loop runs until all enemies are finished
            bool currentEnemyFinished = false;
            int currentEnemiesSpawned = 0;

            while (!currentEnemyFinished)
            {

               
                if (currentEnemy.EnemyAmount < currentEnemiesSpawned)
                {
                    //Ensures enemies are spawned at each spawn point if possible. spawn point will be randomized if there are less enemies remaining to be spawned than there are spawnpoints
                    //e.g. you need to spawn 3 enemies, but you have 4 spawn points --> spawns will be random;
                    if (currentEnemy.EnemyAmount >= SpawnPoints.Count)
                    {
                        foreach (Transform currentSpawnPoint in SpawnPoints)
                        {
                            //Instantiate enemy
                        }
                    }
                }
                else
                {
                    //all enemies spawned; exit the loop
                    currentEnemyFinished = true;
                }

            }
        }
        

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
