using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {


    public float speed;
    private Transform player;
    public float hitpoints;
	public AudioClip audioClip;
    public float damage;
    Camera cam;
    Screenshake shake;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
        cam = GameObject.FindObjectOfType<Camera>();
        shake = (Screenshake) cam.GetComponent(typeof (Screenshake));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - new Vector3(player.transform.position.x, player.transform.position.y, -10), Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        Vector3 move = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0);
        move.Normalize();
        GetComponent<Rigidbody2D>().velocity = new Vector2(move.x * speed, move.y * speed);
 
       
	}

    void Update ()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("collision");
        if (coll.gameObject.tag == "Bullet")
        {
            GameObject bullet = coll.gameObject;
            hitpoints -= bullet.GetComponent<BulletScript>().damagePoints;

            Instantiate(bullet.GetComponent<BulletScript>().impactAnimation, new Vector3(coll.contacts[0].point.x, coll.contacts[0].point.y, 0) , transform.rotation);


			AudioSource.PlayClipAtPoint (audioClip, transform.position);
            if (Random.Range(1,6) == 2)
            {
                Instantiate(bullet.GetComponent<BulletScript>().explosionAnimation, new Vector3(coll.contacts[0].point.x, coll.contacts[0].point.y, 0), transform.rotation);
                // start screenshake
                shake.Shake(2f, 1f, 0.8f);
            }
            Destroy(bullet);
        }
    }
}
