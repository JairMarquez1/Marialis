using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTutorial : MonoBehaviour
{
    public bool isInside;
    private bool auxiliar;

    public void Awake()
    {
        auxiliar = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && auxiliar == true)
            isInside = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInside = false;
            auxiliar = false;
        }
            
    }
}
