using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

    public int columns = 40;                                         //Number of columns in our game board.
    public int rows = 80;                                     //Prefab to spawn for exit.
    public GameObject[] floorTiles;                                 //Array of floor prefabs.

    private GameObject boardHolder;
    private Transform boardHolderTransform;                                  //A variable to store a reference to the transform of our Board object.

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolderTransform to its transform.
        boardHolder = new GameObject("Board");
        boardHolderTransform = boardHolder.transform;

        var totalWidth = 0f;
        var totalHeight = 0f;
        var floorHeight = 0f;

        var floor = new List<Renderer>();

        
        var camera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        for (int x = 1; x < columns; x++)
        {
            for (int y = 1; y <= rows - 6; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                var width = toInstantiate.GetComponent<Renderer>().bounds.size.x;
                var height = toInstantiate.GetComponent<Renderer>().bounds.size.y;
                
                var pos = camera + new Vector3(x * width, y * height);

                GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolderTransform);

            }

            totalHeight = (rows - 6)*floorHeight;

            // Mit 10 Prozentiger WK ein Tile in der dritten Zeile hinzufügen
            if (Random.value > 0.97)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                var width = toInstantiate.GetComponent<Renderer>().bounds.size.x;
                var height = toInstantiate.GetComponent<Renderer>().bounds.size.y;
            
                var pos = camera + new Vector3(x * width, 3 * height);

                GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolderTransform);
            }

        }
     
        BoxCollider2D collider2D = boardHolder.AddComponent<BoxCollider2D>();


        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        bool hasBounds = false;

        foreach (Renderer render in floor)
        {
            if (hasBounds)
            {
                bounds.Encapsulate(render.bounds);
            }
            else
            {
                bounds = render.bounds;
                hasBounds = true;
            }
        }
        if (hasBounds)
        {
            collider2D.offset = bounds.center - transform.position;
            collider2D.size = bounds.size;
        }
        else
        {
            collider2D.offset = Vector3.zero;
            collider2D.size = Vector3.zero;
        }

    }

    void CreateTile(GameObject bh)
    {

    }

    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();
    }
}
