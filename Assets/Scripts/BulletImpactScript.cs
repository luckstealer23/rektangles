using UnityEngine;
using System.Collections;

public class BulletImpactScript : MonoBehaviour {
    public bool kill = false;
	
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
