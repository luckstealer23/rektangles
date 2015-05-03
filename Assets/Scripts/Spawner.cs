using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    Vector3 spawnPoint;
    float diff;


    GameObject spawnEnemy()
    {
        return Instantiate() as GameObject;
        //TODO
    }

    public void setSpawnPoint(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
    public void setEnemy(GameObject asdf)
    {
        //TODO
    }

    public void setSpawnPoint(Vector2 spawnPoint)
    {
        this.spawnPoint = new Vector3(spawnPoint.x, spawnPoint.y, 0f);
    }

    public void setDifficulty(float difficulty)
    {
        this.diff = spawnPoint;
    }

	// Use this for initialization
	void Start () {
        spawnPoint = Vector3.zero;
        diff = 1;
	}
	
}
