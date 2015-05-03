using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Vector3 spawnPoint;
    public float diff;
    public GameObject enemy;


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

	// Use this for initialization
	void Start () {

	}
	
}
