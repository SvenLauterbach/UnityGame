using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour
{

    public Player Player;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Test");
        GameManager.instance.ShowFinishMenu();
        Player.Stop();
    }
}
