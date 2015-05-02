using UnityEngine;
using System.Collections;

public class ImpactShake : MonoBehaviour 
{
	
	Vector3 originalCameraPosition;
	
	
	public Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

	void OnCollisionEnter2D(Collision2D coll) 
	{
		
		shakeAmt = coll.relativeVelocity.magnitude * .0025f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);
		
	}
	
	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}
	
	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}
	
}