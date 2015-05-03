using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    
    //public float damping = 1;
    public float lookAheadFactor = 20;
	public int minDistance = 20;
	public float zoomFactor = 1;
    public float zoomSpeed = 0.08f;
    public float shootLookAheadFactor;

	Transform target;
    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;
	Vector3 enemyPos;
	Vector3 pos;
	GameObject[] enemies;
	Camera cam;
	float aspect;
	float zoom;
    float targetZoom;
    float from;
	int enemyDistanceSqr;


    // Use this for initialization
    void Start()
    {
		//Get player
		target = GameObject.Find("Player").transform;
        lastTargetPosition = target.position;
		offsetZ = transform.position.z;
		currentVelocity = Vector3.zero;
		cam = gameObject.GetComponent<Camera> ();
		aspect = cam.aspect;
		zoom = cam.orthographicSize;
        enemyDistanceSqr = minDistance * minDistance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

		pos = target.position;
		pos.z = offsetZ;

		Vector3 change = target.position - lastTargetPosition;
		change.Normalize();
		lookAheadPos = new Vector3 (lookAheadFactor * aspect * (change.x), lookAheadFactor * (change.y), 0f);
		pos += lookAheadPos;

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject furthestEnemy = null;
		foreach (GameObject enemy in enemies) {

			Vector3 dist = enemy.transform.position - target.position;

			if(dist.sqrMagnitude > enemyDistanceSqr)
				break;

            if (furthestEnemy == null || (furthestEnemy.transform.position - target.position).sqrMagnitude < dist.sqrMagnitude)
				furthestEnemy = enemy;
		}

        if (furthestEnemy != null)
        {
            float closeness = (furthestEnemy.transform.position - target.position).sqrMagnitude / enemyDistanceSqr;
            targetZoom = zoom + zoom * closeness * zoomFactor;
        }
        else targetZoom = zoom;

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 shootDirection = new Vector2(mousePosition.x - target.transform.position.x, mousePosition.y - target.transform.position.y);
        shootDirection.Normalize();
        pos.x += shootDirection.x * shootLookAheadFactor;
        pos.y += shootDirection.y * shootLookAheadFactor;


        from = cam.orthographicSize;
        cam.orthographicSize = Mathf.Lerp(from, targetZoom, zoomSpeed);

		transform.position = Vector3.SmoothDamp (transform.position, pos, ref currentVelocity, 0.3f);
		lastTargetPosition = target.position;
    }
}