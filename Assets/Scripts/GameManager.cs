using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    Spawner spawner;

	bool spawning;
	Image img;
	float timeSinceSpawn;


	// Use this for initialization
	void Start () {
        spawner = GetComponent<Spawner>();
		img =  GameObject.Find("SpawningImg").GetComponent<Image>();
		timeSinceSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S))
			spawning = !spawning;
        
		spawn ();
	}

	void spawn(){
		if (spawning && timeSinceSpawn > 1) {
			spawner.spawnEnemy ();
			img.color = Color.red;
			timeSinceSpawn = 0;
		} else if(spawning) timeSinceSpawn += Time.deltaTime;
		else img.color = Color.green;
			

	}
}
