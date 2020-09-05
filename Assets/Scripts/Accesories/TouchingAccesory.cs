using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingAccesory : MonoBehaviour
{
    public bool isTouching;

    private void Awake()
    {
        isTouching = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouching = false;
        }
    }



}
