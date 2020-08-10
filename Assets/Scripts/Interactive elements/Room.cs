using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public SpriteRenderer blackScreen;
    public SpriteRenderer outsideShip;
    public GameObject barriers;
    public GameObject door;
    public Movement player;
    public SpriteRenderer playerSp;

    public bool isInside;
    public bool isTouchingDoor;
    public bool isOpeningDoor;
    private float opacityTime = 1.5f;
    private float opacity;
    private float doorOriginPos;

    private void Start()
    {
        isInside = false;
        isTouchingDoor = false;

        opacity = 0.25f;
        opacity = 0;

        doorOriginPos = door.transform.position.y;
        door.GetComponent<Animator>().SetBool("ActivateDoor", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouchingDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingDoor = false;
    }


    private void Update()
    {
        GetOut_ComeIn();
    }


    public void GetOut_ComeIn()
    {
        if (isTouchingDoor == true && Input.GetKeyDown(KeyCode.X) && player.grounded == true)
        {
            isOpeningDoor = true;
            isInside = !isInside;
            //outsideShip.sortingOrder = 2 * Convert.ToInt32(isInside);
            //door.GetComponent<SpriteRenderer>().sortingOrder = 2 * Convert.ToInt32(isInside);
            playerSp.sortingOrder = -2 * Convert.ToInt32(isInside);
            doorAnimation(true);
        }
        else
        {
            isOpeningDoor = false;
            doorAnimation(false);
        }

        activateBarriers(isInside);
    }



    public void activateBarriers(bool state)
    {
        barriers.gameObject.SetActive(state); //Activa / Desactiva los muros.
    }

    public void doorAnimation(bool state)
    {
        door.GetComponent<Animator>().SetBool("ActivateDoor", state); //Activa / Desactiva la animación.
    }
}




