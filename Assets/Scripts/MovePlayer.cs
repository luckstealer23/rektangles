using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    public float speed;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed / 100;
	}
}
