using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    
    //public float damping = 1;
    public float lookAheadFactor = 20;
	public float enemyFactor = 0.1f;
	public int maxEnemyFactor = 40;

	Transform target;
    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;
	Vector3 enemyPos;
	Vector3 pos;
	GameObject[] enemies;
	int notMoving;
	float aspect;

    // Use this for initialization
    void Start()
    {
		//Get player
		target = GameObject.Find("Player").transform;
        lastTargetPosition = target.position;
		offsetZ = transform.position.z;
		currentVelocity = Vector3.zero;
		notMoving = 0;
		aspect = gameObject.GetComponent<Camera>().aspect;
    }

    // Update is called once per frame
    void Update()
    {

        // only update lookahead pos if accelerating or changed direction
        
		/*float xMoveDelta = (target.position - lastTargetPosition).x;
        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);*/

		//check if player moving

		// {

		pos = target.position;
		pos.z = offsetZ;

		if (target.position != lastTargetPosition || notMoving > 2) {
			Vector3 change = target.position - lastTargetPosition;
			change.Normalize();
			lookAheadPos = new Vector3 (lookAheadFactor * aspect * (change.x), lookAheadFactor * (change.y), 0f);
			pos += lookAheadPos;
		

			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			enemyPos = Vector3.zero;
			foreach (GameObject enemy in enemies) {
				if (Mathf.Abs (enemyPos.x) > maxEnemyFactor || Mathf.Abs (enemyPos.y) > maxEnemyFactor)
					break;
				Vector3 dist = enemy.transform.position - target.position;
				enemyPos.x += dist.x * enemyFactor;
				enemyPos.y += dist.y * enemyFactor;
                enemyPos.z = 0f;
			}
			pos += enemyPos;

			transform.position = Vector3.SmoothDamp (transform.position, pos, ref currentVelocity, 0.3f);

			if (target.position != lastTargetPosition){
				notMoving = 0;
				lastTargetPosition = target.position;
			}

		}
		else notMoving++;

    }
}