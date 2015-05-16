using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour {

    public Camera cam;
    float shakeStrength;
    float shakeDecay;

    public void Shake(float strength,  float decay)
    {
        shakeStrength = strength;
        shakeDecay = decay;
    }

	void Start () {
        
	}
	

	void FixedUpdate () {
        if (shakeStrength > 0.01f)
        {
            cam.transform.position += new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0f) * shakeStrength;
            
            shakeStrength = shakeStrength * shakeDecay;
            
        }
        else shakeStrength = 0f;
    
	}
}
