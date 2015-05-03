using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    Spawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount % 100 == 0)
            spawner.spawnEnemy();
	}
}
