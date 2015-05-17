using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    public float speed;

	Animator animator;
    GameManager gm;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
        gm = GameObject.Find("GM").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

		Vector3 newPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * speed / 100;
        
		if (newPos != Vector3.zero) {
			transform.position += newPos;
			animator.SetBool ("moving", true);
		} else
			animator.SetBool ("moving", false);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("coll");
        if (coll.gameObject.tag == "Enemy")
        {
            EnemyScript enemy = coll.gameObject.GetComponent<EnemyScript>();
            gm.hit(enemy.damage);
            enemy.destroy();

        }
    }
}
