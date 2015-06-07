using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


    float timeInitialized;
    public float lifeTime;
    public float damagePoints;
    public GameObject impactAnimation;
    public GameObject explosionAnimation;
    public AudioClip audioClip;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AnimationFinished"))
        {
            Debug.Log("animation finished, will destroy GO now");
            Destroy(gameObject);
        }

        if (Time.time > timeInitialized + lifeTime)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        animator.SetTrigger("ImpactHappened");
        Debug.Log("trigger");
        
        //Actual Code, to be changed drastically
        //Destroy(gameObject);
        //add explosion of sorts here
    }
}
