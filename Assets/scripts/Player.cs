using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
    public float speed;

    private Rigidbody2D rig;
    private Vector3 oldposition;

	void Start ()
    {
	    rig = GetComponent<Rigidbody2D>();
	    transform.position = BoardManager.Instance.StartPosition;
    }
	
	// Update is called once per frame
	void Update () 
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(speed, 0);
        //Vector3 move = new Vector3(speed, 0, 0);
        Vector2 nw = new Vector2(1,ver*2);
        

        //rig.MovePosition(new Vector2(hor, this.transform.position.y));
        //rig.MovePosition(new Vector2(hor, ver));

        rig.velocity = nw * speed;

        //rig.AddForce(movement);
        //rig.MovePosition(this.transform.position + move);
	}
}
