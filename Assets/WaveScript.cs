using UnityEngine;
using System.Collections;
using System;

public class WaveScript : MonoBehaviour {

    [Serializable]
    public class EnemyInfo
    {
        public GameObject EnemyPrefab;
        public int EnemyAmount;
        public int SpawnPriority;
    }

    public EnemyInfo[] EnemiesToSpawn;
    public float SpawnDelay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
