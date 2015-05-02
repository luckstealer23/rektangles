using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    public float speed;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

		Vector3 newPos = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed / 100;
		if (newPos != Vector3.zero) {
			transform.position += newPos;
			animator.SetBool ("moving", true);
		} else
			animator.SetBool ("moving", false);
	}
}
