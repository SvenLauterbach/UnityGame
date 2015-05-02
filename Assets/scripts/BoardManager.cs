﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    // Using Serializable allows us to embed a class with sub properties in the inspector.
    [Serializable]
    public class Count
    {
        public int minimum;             //Minimum value for our Count class.
        public int maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public class CameraViewPort
    {
        public int minX { get; set; }
        public int maxX { get; set; }

        public int minY { get; set; }
        public int maxY { get; set; }
    }

    public int columns;                                         //Number of columns in our game board.
    public int rows;                                     //Prefab to spawn for exit.
    public GameObject[] floorTiles;                                 //Array of floor prefabs.
    public GameObject[] lowerFloor;

    private Transform boardHolder;   //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();   //A list of possible locations to place tiles.
    public GameObject FloorCollider;


    //Clears our list gridPositions and prepares it to generate a new board.
    //void InitialiseList()
    //{
    //    Clear our list gridPositions.
    //    gridPositions.Clear();

    //    Loop through x axis (columns).
    //    for (int x = 1; x < columns - 1; x++)
    //    {
    //        Within each column, loop through y axis (rows).
    //        for (int y = 1; y < rows - 1; y++)
    //        {
    //            At each index add a new Vector3 to our list with the x and y coordinates of that position.
    //            gridPositions.Add(new Vector3(x, y, 0f));
    //        }
    //    }
    //}


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

        for (int y = 1; y <= rows; y++)
        {
            CreateTile(columns, y, boardHolder, 1, lowerFloor);
        }

        BoxCollider2D collider2D = FloorCollider.AddComponent<BoxCollider2D>();

        collider2D.transform.position = new Vector2(0, 0);
        collider2D.size = new Vector2(0.32f * columns, 0.32f * 2);
            
    }

    public void CreateTile(int x, int y, Transform bh, float scale, GameObject[] tileset)
    {
        GameObject toInstantiate = tileset[Random.Range(0, tileset.Length)];
        var width = toInstantiate.GetComponent<Renderer>().bounds.size.x;
        var height = toInstantiate.GetComponent<Renderer>().bounds.size.y;



        var camera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        var pos = camera + new Vector3(x * width, y * height);

        GameObject instance = Instantiate(toInstantiate, pos, Quaternion.identity) as GameObject;

        instance.transform.SetParent(bh);
    }


    //RandomPosition returns a random position from our list gridPositions.
    Vector3 RandomPosition()
    {
        //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
        int randomIndex = Random.Range(0, gridPositions.Count);

        //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
        Vector3 randomPosition = gridPositions[randomIndex];

        //Remove the entry at randomIndex from the list so that it can't be re-used.
        gridPositions.RemoveAt(randomIndex);

        //Return the randomly selected Vector3 position.
        return randomPosition;
    }


    //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        //Choose a random number of objects to instantiate within the minimum and maximum limits
        int objectCount = Random.Range(minimum, maximum + 1);

        //Instantiate objects until the randomly chosen limit objectCount is reached
        for (int i = 0; i < objectCount; i++)
        {
            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition();

            //Choose a random tile from tileArray and assign it to tileChoice
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();

        //Reset our list of gridpositions.
        //InitialiseList();
    }
}
