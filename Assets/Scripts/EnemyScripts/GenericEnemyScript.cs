using UnityEngine;
using System.Collections;

public class GenericEnemyScript : MonoBehaviour {

    //Important variables for generic enemy traits
    public float health;
    //the total game time at which the physics interaction of the enemy will end
    float physicsEndTime;
    //These store important gameobjects on spawn to make sure performance is saved when there is need for them to be called
    GameObject player;
    Camera camera;
    GameObject waveManager;
    


  

	public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindObjectOfType<Camera>();
        waveManager = GameObject.FindGameObjectWithTag("WaveManager");
        
    }



	void Update () {
        if (health > 0)
        {
            if (!PhysicsActive())
            {
                
                //call enemy logic here
            }
        }
        else
        {
            DestroyEnemy();
        }
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            //if player kill player yadayadayada
        }
    }



    public void DestroyEnemy()
    {
        waveManager.GetComponent<WaveGenerator>().EnemyDied();
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
