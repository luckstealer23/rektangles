using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


    float timeInitialized;
    public float lifeTime;
    public float damagePoints;
    public GameObject impactAnimation;
    public GameObject explosionAnimation;


	// Use this for initialization
	void Start () {
	
	}

    public void Init(float speed, Vector2 direction, Quaternion rotation, float timeToLive, float damage)
    {
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        timeInitialized = Time.time;
        lifeTime = timeToLive;
        damagePoints = damage;
    }
    
	// Update is called once per frame
	void Update () {
	    //do collision checks here etc.
        //kill after time expired
        if (Time.time > timeInitialized + lifeTime)
        {
            Destroy(gameObject);
        }
	}
}
