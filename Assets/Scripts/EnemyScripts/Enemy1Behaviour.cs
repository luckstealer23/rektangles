using UnityEngine;
using System.Collections;

public class Enemy1Behaviour : MonoBehaviour {

    //These store important gameobjects on spawn to make sure performance is saved when there is need for them to be called
    GameObject player;
    Camera camera;
    GameObject waveManager;
    

    public void StartUp (GameObject playerGO, Camera cameraCam, GameObject waveManagerGO)
    {
        player = playerGO;
        camera = cameraCam;
        waveManager = waveManagerGO;
        Debug.Log("working nicely!!0");
    }

    public void RunLogic ()
    {
        //The rotation "rot" is the rotation needed for the enemy to be facing the player GO
        Quaternion rot = Quaternion.LookRotation(transform.position - new Vector3(player.transform.position.x, player.transform.position.y, -10), Vector3.forward);
    }

}
