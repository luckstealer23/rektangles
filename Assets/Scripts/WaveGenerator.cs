using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WaveGenerator : MonoBehaviour {


    public GameObject[] WavePrefabs;
    //Get all the Waves that can be spawned here
    List<WaveScript> Waves = new List<WaveScript>();
    //pause between the player finishing one wave and spawning the next
    public float WavePause;
    //Determines wether the WaveGenerator should be active (the game has started)
    public bool DoSpawnWaves = false;
    //sets the Spawnpoints (will be set by the MapManager)
    public List<Transform> SpawnPoints = new List<Transform>();

    //general administrative variables
    public int RandomSeed;
    int difficulty = 1;
    float waveDelayTimer;



    //variables used for actually spawning the wave
    int livingEnemies = 0;
    WaveScript thisWave = new WaveScript();
    float waveStartedTime;
    int currentEnemyIndex = 0;
    float lastEnemySpawnedTime = 0;
    bool waveSpawning = false;





	// Use this for initialization
	void Start () {
        RandomSeed = Random.Range(1, 10000);
        Random.seed = RandomSeed;

        foreach (GameObject wavePrefab in WavePrefabs)
        {
            GameObject toBeAdded = (Instantiate(wavePrefab, new Vector3(0, 0, 0), new Quaternion())) as GameObject;
            Waves.Add(toBeAdded.GetComponent<WaveScript>());
        }
	}
	
  


	// Update is called once per frame
	void Update () {
	    if (DoSpawnWaves)
        {
            if (nextWave() && Time.time >= waveDelayTimer + WavePause)
            {
                SpawnWave(difficulty);
                waveStartedTime = Time.time;
            }

            //is it time to spawn a new enemy?
            if (waveSpawning)
            {
                //Debug.Log("waveSpawning = true");
                if (Time.time >= lastEnemySpawnedTime + thisWave.SpawnDelay)
                {
                    //Debug.Log("Time to spawn something");
                    //do this for each spawn point
                    foreach (Transform currenSpawnPoint in SpawnPoints)
                    {
                        if (thisWave.EnemiesToSpawn[currentEnemyIndex].EnemyAmount > 0)
                        {
                            Debug.Log("spawned an enemy!");
                            Instantiate(thisWave.EnemiesToSpawn[currentEnemyIndex].EnemyPrefab, currenSpawnPoint.position, new Quaternion());
                            livingEnemies += 1;
                            thisWave.EnemiesToSpawn[currentEnemyIndex].EnemyAmount -= 1;
                            lastEnemySpawnedTime = Time.time;
                        }
                        //if the last type of enemy spawned isnt the last one in the list, then go to the next enemy in the list
                        else if (currentEnemyIndex < thisWave.EnemiesToSpawn.Count - 1)
                        {
                            currentEnemyIndex += 1;
                            Debug.Log("Next type of enemy!");
                            Debug.Log("Enemy types to spawn count: " + thisWave.EnemiesToSpawn.Count);
                            Debug.Log("currentEnemyIndex: " + currentEnemyIndex);
                        }
                        //if every enemy has been spawned turn off wave spawning to save on unnecessary calculations
                        else
                        {
                            lastEnemySpawnedTime = 0;
                            waveSpawning = false;
                            difficulty += 1;
                            waveDelayTimer = Time.time;

                            Debug.Log("Wave spawning finished!");
                        }
                        

                    }
                    

                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.P))
            DoSpawnWaves = !DoSpawnWaves;
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

        if (randomWaves.Count != 0)
        {
            //make the current wave the one that has been randomly selected
            
            thisWave = randomWaves[Random.Range(0, randomWaves.Count)];
            //sort the current wave by enemy priority
            thisWave.EnemiesToSpawn.Sort(SortBySpawnPriority);
            //activate the spawning of the current wave
            waveSpawning = true;
            //resetting some variables
            currentEnemyIndex = 0;
            Debug.Log("Wave spawning started successfully! Difficulty Level: " + waveLevel);
        }
        else
        {
            //since there is no current wave (should never happen!!!) since there wasnt one that had the required difficulty level disable wave spawning
            waveSpawning = false;
            Debug.Log("Critical Error! No wave with required difficulty level found! (For difficulty level: " + waveLevel + ")");
        }
    }

    
    //used to sort the enemies to be spawned by their priority value
    private static int SortBySpawnPriority(WaveScript.EnemyInfo e1, WaveScript.EnemyInfo e2)
    {
        return e1.SpawnPriority.CompareTo(e2.SpawnPriority);
    }

    public void EnemyDied()
    {
        livingEnemies -= 1;
        Debug.Log(livingEnemies);
    }


    bool nextWave()
    {
        if (Time.time - waveStartedTime >= thisWave.MaxWaveLength || livingEnemies <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
     
}
