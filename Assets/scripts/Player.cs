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
	    //transform.position = BoardManager.Instance.StartPosition;
    }
	
	// Update is called once per frame
	void Update () 
    {
        float ver = Input.GetAxis("Vertical");

        Vector2 nw = new Vector2(1,ver*2);

        rig.velocity = nw * speed;
	}

    public void Stop()
    {
        rig.velocity = new Vector2(0f, 0f);
    }
}
