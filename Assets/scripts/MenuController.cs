using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void ClickButton(string buttonID)
    {
        Application.LoadLevel("level");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
