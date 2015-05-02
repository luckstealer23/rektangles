using UnityEngine;
using System.Collections;

public class BulletImpactScript : MonoBehaviour {
    public bool kill = false;
	public AudioClip audioClip;

	void Start() 
	{
		if (audioClip != null) {
			AudioSource.PlayClipAtPoint (audioClip, transform.position, 0.5f);
		}
	}


    void Kill(bool killMe)
    {
        if (killMe)
        {
            kill = killMe;
        }
    }

    void Update ()
    {
        if (kill)
        {
            Destroy(gameObject);
        }
    }
}
