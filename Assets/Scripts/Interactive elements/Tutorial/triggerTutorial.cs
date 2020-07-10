using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTutorial : MonoBehaviour
{
    public bool isNoob;

    public void Start()
    {
        isNoob = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNoob = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNoob = false;
    }
}
