using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public int columns = 80;                                         //Number of columns in our game board.
    public int rows = 8;                                     //Prefab to spawn for exit.
    public GameObject[] floorTiles;                                 //Array of floor prefabs.

    private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.

    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        var leftBottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y <= rows - 6; y++)
            {
                //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                var width = toInstantiate.GetComponent<Renderer>().bounds.size.x;
                var height = toInstantiate.GetComponent<Renderer>().bounds.size.y;

                var pos = leftBottomCorner + new Vector3(x * width, y * height);

                GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        BoardSetup();
    }
}
