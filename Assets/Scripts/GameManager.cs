using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    Spawner spawner;
    Screenshake shaker;
    HealthManager healther;


	// Use this for initialization
	void Start () {
        spawner = GetComponent<Spawner>();
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Screenshake>();
        healther = GetComponent<HealthManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void die()
    {
        //TODO: Play death animation
        //TODO: Game Over screen; unload level
    }

    public void hit(float damage)
    {
        //TODO: Play hit animation (blinking?)
        //TODO: Explosion?

        healther.updateHealth(damage);
        shaker.Shake(3f, 1.5f, 0.8f);

    }

}
