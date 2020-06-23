using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public SpriteRenderer blackScreen;
    public SpriteRenderer outsideShip;
    public GameObject barriers;
    public GameObject door;
    public Movement player;

    public bool isInside;
    public bool isTouchingDoor;
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
            if (isInside==true)
                isInside = false; //Saliendo.
            else
                isInside = true; //Entrando.

            doorAnimation(true);
        }
      else
        {
            doorAnimation(false);
        }
           
        transition(isInside);
    }

    public void transition(bool inside)
    {
        objectsOpacity(inside);
        activateBarriers(inside);    
    }

    public void objectsOpacity(bool state)
    {
        if(state == true)
            opacity += opacityTime * Time.deltaTime; //Aumenta progresivamente la opacidad.
        else
            opacity -= opacityTime * Time.deltaTime; //Disminuye progresivamente la opacidad.

        blackScreen.color = new Color(0f, 0f, 0f, opacity); //Pantalla negra.
        outsideShip.color = new Color(1f, 1f, 1f, -opacity + 1f); //Superficie exterior.
         
        door.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (-opacity * 1/2) + 1f); //Puerta

        opacity = Mathf.Clamp(opacity, 0, 1); 
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





