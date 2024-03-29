﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	// Use this for initialization

    public float fireRate = 0;
    public float damage = 1;
    public GameObject bullet;
    public float bulletSpeed;
	public AudioClip audioClip;

    float timeToFire = 0;
    Transform firePoint;
	void Awake () {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint found! Contact the moron who developed this!");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Vector2 shootDirection;

        if (Input.GetJoystickNames()[0] == "Controller (XBOX One For Windows)")
        {
            shootDirection = new Vector2(Input.GetAxis("RightStickHorizontal"), Input.GetAxis("RightStickVertical"));
            Debug.Log(shootDirection);
        }
        else
        {
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            shootDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        }  
        

        GameObject projectile;
        projectile = (Instantiate(bullet, firePoint.position, transform.rotation)) as GameObject;
        BulletScript projectileScript = projectile.GetComponent<BulletScript>();
        projectileScript.Init(bulletSpeed, shootDirection, transform.rotation, 3f, damage);

		AudioSource.PlayClipAtPoint (audioClip, transform.position, 0.08f);

        int i = Input.GetJoystickNames().Length;
        for (int f = 0; f < i; f++)
        {
         //   Debug.Log(Input.GetJoystickNames()[f]);
           // Debug.Log(f);
        }
    }
}
