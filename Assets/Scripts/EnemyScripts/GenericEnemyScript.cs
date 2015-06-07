using UnityEngine;
using System.Collections;

public class GenericEnemyScript : MonoBehaviour {

    //the total game time at which the physics interaction of the enemy will end
    float physicsEndTime;

    GameObject player;
    Camera camera;
    GameObject waveManager;


	public void StartUp()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindObjectOfType<Camera>();
        waveManager = GameObject.FindGameObjectWithTag("WaveManager");
    }



	void Update () {
	    if (!PhysicsActive())
        {
            //call enemy logic here
        }
	}

    void OnCollisionEnter2D (Collision2D collisions)
    {
        //if player kill player yadayadayada
    }

    //call this function to suspend player movement and let them be affected by physics
    public void ActivatePhysics (float physicsLength)
    {
        //adds the desired amount of time to the physics end time, making physics active until the tmie runs out
        physicsEndTime = Time.time + physicsLength;
    }

    public bool PhysicsActive ()
    {
        if (Time.time <= physicsEndTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
