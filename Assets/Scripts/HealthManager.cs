using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public float maxHealth = 100f;
   
    float health;
    GameManager gm;
    Slider slider;

    public float updateHealth(float damage)
    {
        health -= damage;
        if (health < 0)
            gm.die();

        slider.value = health;

        return health;
    }

    void resetHealth() {
        health = maxHealth;
    }

    public float getHealth()
    {
        return health;
    }

    public void ini()
    {
        resetHealth();
        gm = GetComponent<GameManager>();
        GameObject temp = GameObject.Find("HealthSlider") as GameObject;
        slider = temp.GetComponent<Slider>();

        slider.maxValue = maxHealth;
    }

	// Use this for initialization
	void Start () {

        //Call this after loading the Scene. It needs to load things like the Health slider;
        ini();
	}
	
}
