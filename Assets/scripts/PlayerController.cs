using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

	    Rigidbody2D rig = this.GetComponent<Rigidbody2D>();

        rig.MovePosition(new Vector2(hor, ver));
	}
}
