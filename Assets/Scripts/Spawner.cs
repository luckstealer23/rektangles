using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public Vector3 spawnPoint;
    public float diff;
    public GameObject enemy;


    bool spawning;
    Image img;
    float timeSinceSpawn;


    public GameObject spawnEnemy()
    {
        return Instantiate(enemy, spawnPoint, new Quaternion()) as GameObject;
    }
    
    public void setSpawnPoint(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
    public void setEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }
    public void setSpawnPoint(Vector2 spawnPoint)
    {
        this.spawnPoint = new Vector3(spawnPoint.x, spawnPoint.y, 0f);
    }
    public void setDifficulty(float difficulty)
    {
        this.diff = difficulty;
    }

    void spawn()
    {
        if (spawning && timeSinceSpawn > 0.3f)
        {
            spawnEnemy();
            img.color = Color.red;
            timeSinceSpawn = 0;
        }
        else if (spawning) timeSinceSpawn += Time.deltaTime;
        else img.color = Color.green;


    }

	// Use this for initialization
	void Start () {
        img = GameObject.Find("SpawningImg").GetComponent<Image>();
        timeSinceSpawn = 0;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            spawning = !spawning;

        spawn();
    }
	
}
