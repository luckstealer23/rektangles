using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Cleaned up part
    public GameObject MapGenPrefab;
    public GameObject PlayerPrefab;
    public Vector3 PlayerSpawnPosition;
    public GameObject CameraPrefab;

    GameObject mapGenerator;
    GameObject player;
    GameObject camera;


    //To be cleaned up
    Spawner spawner;
    Screenshake shaker;
    HealthManager healther;


	void Start () {
        //cleaned up part
        InstantiateObjects();
        InitializeObjects();


        //to be cleaned up
        spawner = GetComponent<Spawner>();
        shaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Screenshake>();
        healther = GetComponent<HealthManager>();
        
	}
	
    void InstantiateObjects ()
    {
        //Map Generator
        if (MapGenPrefab != null)
        {
            mapGenerator = (Instantiate(MapGenPrefab, new Vector3(0, 0, 0), new Quaternion())) as GameObject;
            mapGenerator.name = "MapGenerator";
        }
        //Player
        if (PlayerPrefab != null)
        {
            player = (Instantiate(PlayerPrefab, PlayerSpawnPosition, new Quaternion())) as GameObject;
            player.name = "Player";
        }
        //Camera
        if (CameraPrefab != null)
        { 
            camera = (Instantiate(CameraPrefab, new Vector3(PlayerSpawnPosition.x, PlayerSpawnPosition.y, -10f), new Quaternion())) as GameObject;
            camera.name = "Camera";
        }
    }


    void InitializeObjects() 
    {
        //Map Generator
        mapGenerator.GetComponent<GenerateMap>().Generate();

        //Camera
        camera.GetComponent<CameraFollow>().StartUp();
    }

	void Update () {
		
	}

    public void die()
    {
        //TODO: Play death animation
        //TODO: Game Over screen; unload level
    }

    public void hit(float damage)
    {
        //TODO: Play hit animation (blinking?)
        //TODO: Explosion?

        //healther.updateHealth(damage);
        //shaker.Shake(3f, 1.5f, 0.8f);

    }

}
