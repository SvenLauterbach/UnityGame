using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public int columns;                                         //Number of columns in our game board.
    public int rows;                                     //Prefab to spawn for exit.
    public GameObject[] floorTiles;                                 //Array of floor prefabs.
    public GameObject[] lowerFloor;

    public static BoardManager Instance { get; private set; }

    private Transform boardHolder;   //A variable to store a reference to the transform of our Board object.
    private Vector3 lowerLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }   
    }

    public Vector2 StartPosition { get; private set; }

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;
        

        for (int x = 1; x < columns; x++)
        {
            CreateTile(x, 1, boardHolder, 1, lowerFloor);
            CreateTile(x, 2, boardHolder, 1, floorTiles);
            
            //for (int y = 1; y <= rows - 10; y++)
            //{
            //    CreateTile(x, y, boardHolder, 1);
            //}

            // Mit WK ein Tile in der dritten Zeile hinzufügen
            if (Random.value > 0.95)
            {
                CreateTile(x, 3, boardHolder, 0.5f, floorTiles);
            }

            // Mit WK ein Tile in der vorletzten Zeile hinzufügen
            if (Random.value > 0.99)
            {
                CreateTile(x, rows-1, boardHolder, 0.5f, floorTiles);
            }

            //Decke
            CreateTile(x, rows, boardHolder, 1, lowerFloor);
        }

        StartPosition = lowerLeftCorner + new Vector3(1*1f, (2*0.32f) + 1f);

        for (int y = 1; y <= rows; y++)
        {
            CreateTile(columns, y, boardHolder, 1, lowerFloor);
        }

            
    }

    public void CreateTile(int x, int y, Transform bh, float scale, GameObject[] tileset)
    {
        GameObject toInstantiate = tileset[Random.Range(0, tileset.Length)];
        var width = toInstantiate.GetComponent<Renderer>().bounds.size.x;
        var height = toInstantiate.GetComponent<Renderer>().bounds.size.y;

        var pos = lowerLeftCorner + new Vector3(x * width, y * height);

        GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

        instance.transform.SetParent(bh);
    }

    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();
    }
}
