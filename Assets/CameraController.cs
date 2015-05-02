using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        //offset = transform.position - Player.transform.position;


        //offset = new Vector3(transform.position.x - Player.transform.position.x, 0,0);
	    //transform.position = Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Player.transform.position + offset;

        //transform.position = new Vector3(Player.transform.position.x + offset.x, 0f,0f);

	}
}
