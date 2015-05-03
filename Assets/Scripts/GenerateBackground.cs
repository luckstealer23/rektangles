using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GenerateBackground : MonoBehaviour {

    public int columns = 16;
    public int rows = 9;
    public GameObject[] floorTiles;
    public float tileSize;
    public float boardZ;
    //add more types of tiles here if wished; e.g. walls/enemy spawns/traps

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns -1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x * tileSize, y * tileSize, boardZ));
            }
        }
    }

    void SetupFloor ()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = 0; x < gridPositions.Count; x++ )
        {
            GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
            GameObject instance = Instantiate(toInstantiate, gridPositions[x], Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);
        }
    }

    

	// Use this for initialization
	void Start () {
        InitialiseList();
        SetupFloor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
