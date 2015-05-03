using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
    public float speed;

    private Rigidbody2D rig;
    private Vector3 oldposition;
    private bool isStopped;

	void Start ()
    {
	    rig = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        float ver = Input.GetAxis("Vertical");

        Vector2 nw = new Vector2(1,ver*2);

	    if (!isStopped)
	    {
	        rig.velocity = nw*speed;
	    }
    }

    public void Stop()
    {
        rig.velocity = new Vector2(0f, 0f);
        GetComponent<Animation>().
        isStopped = true;
    }
}
