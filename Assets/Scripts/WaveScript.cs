using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class WaveScript : MonoBehaviour {

    [Serializable]
    public class EnemyInfo
    {
        public GameObject EnemyPrefab;
        public int EnemyAmount;
        public int SpawnPriority;
    }


    //stores all the enemy information conveniently
    public List<EnemyInfo> EnemiesToSpawn;
    //Delay between the enemies spawning: e.g. 0.5f will spawn 2 emeies per second
    public float SpawnDelay;
    //Level of Difficulty of the wave
    public int DifficultyLevel;
    //max amount of time the player has to complete the wave; if he does not clear the wave in time the next wave will spawn regardless of enemies still being around
    public float MaxWaveLength;

	// Use this for initialization
	void Start () {
            
	}
	
    
	// Update is called once per frame
	void Update () {
	
	}
}
