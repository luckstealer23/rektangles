using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour {

    public Camera cam;
    float time;
    float shakeStrength;
    float shakeLength;
    float shakeDecay;

    public void Shake(float strength, float maxLength, float decay)
    {
        time = 10;
        shakeStrength = strength;
        shakeLength = (10 / maxLength);
        shakeDecay = decay;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (time>0f)
        {
            cam.transform.position += new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0f) * shakeStrength;
            
            time -= shakeLength * Time.deltaTime;
            shakeStrength = shakeStrength * shakeDecay;
            
        }
        else if (shakeStrength < 0.01f) time = 0f;
        else time = 0f;
    
	}
}
