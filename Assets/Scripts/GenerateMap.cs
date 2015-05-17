using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GenerateMap : MonoBehaviour {

    public int columns = 16;
    public int rows = 9;
    public GameObject[] floorTiles;
    public float tileSize;
    public float boardZ;
    //just a GO with a boxcollider2D
    public GameObject boardWallPrefab;

    //add more types of tiles here if wished; e.g. walls/enemy spawns/traps
    public Vector3 center;
    float width;
    float heigth;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x <= columns; x++)
        {
            for (int y = 1; y <= rows; y++)
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

    public void Generate ()
    {
        InitialiseList();
        SetupFloor();
    }

	void Start () {
        boardHolder = new GameObject("Board").transform;
        center = new Vector3((columns  + 1) * tileSize * 0.5f , (rows + 1) * tileSize * 0.5f, boardZ);
        width = columns * tileSize;
        heigth = rows * tileSize;

        GameObject topWall = Instantiate(boardWallPrefab, new Vector3(center.x, center.y + heigth / 2 + tileSize / 2, boardZ), new Quaternion()) as GameObject;
        topWall.GetComponent<BoxCollider2D>().size = new Vector2(width + tileSize, tileSize);
        topWall.transform.SetParent(boardHolder);

        GameObject bottomWall = Instantiate(boardWallPrefab, new Vector3(center.x, center.y - heigth / 2 - tileSize / 2, boardZ), new Quaternion()) as GameObject;
        bottomWall.GetComponent<BoxCollider2D>().size = new Vector2(width + tileSize, tileSize);
        bottomWall.transform.SetParent(boardHolder);

        GameObject leftWall = Instantiate(boardWallPrefab, new Vector3(center.x - width / 2 - tileSize / 2, center.y, boardZ), new Quaternion()) as GameObject;
        leftWall.GetComponent<BoxCollider2D>().size = new Vector2(tileSize, heigth + tileSize);
        leftWall.transform.SetParent(boardHolder);

        GameObject rightWall = Instantiate(boardWallPrefab, new Vector3(center.x + width / 2 + tileSize / 2, center.y, boardZ), new Quaternion()) as GameObject;
        rightWall.GetComponent<BoxCollider2D>().size = new Vector2(tileSize, heigth + tileSize);
        rightWall.transform.SetParent(boardHolder);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
