using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheking : MonoBehaviour
{
    private Movement script;
    private GameObject player;
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
        script = player.GetComponent<Movement>();
        script.set_ground(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            script.set_ground(true);
            //Debug.Log("true");
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            script.set_ground(false);
            Debug.Log("false");
        }
    }*/
}
