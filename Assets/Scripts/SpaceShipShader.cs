using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipShader : MonoBehaviour
{
    public SpriteRenderer blackScreen;
    public SpriteRenderer outsideShip;
    public GameObject barriers;

    private bool isInside = false;
    private float opacityTime = 0.025f;
    private float opacity = 0f;

    private void Start()
    {
        isInside = false;
        opacity = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronauta1")    
            isInside = true;
        else 
            isInside = false;      
    }

    private void FixedUpdate()
    {
        EvaluateInside(); 
    }


    public void EvaluateInside()
    {
        if(isInside == true)
        {
            stateOpacity(true);
            stateSortingOrder(true);
            stateBarriers(true);
        }
        else
        {
            stateOpacity(false); 
            stateSortingOrder(false); 
            stateBarriers(false);
        }
    }

    public void stateOpacity(bool state)
    {
        if(state == true)
            opacity += opacityTime; //Aumenta progresivamente la opacidad.
        else
            opacity -= opacityTime; //Disminuye progresivamente la opacidad.

        blackScreen.color = new Color(0f, 0f, 0f, opacity); //Pantalla negra.
        outsideShip.color = new Color(1f, 1f, 1f, -opacity + 1f); //Script de la superficie exterior.

        opacity = Mathf.Clamp(opacity, 0, 1); 
    } 

    public void stateSortingOrder(bool state) //Cambia el orden de dibujado.
    {
        if(state == true)
            outsideShip.sortingOrder = 1; 
        else
            outsideShip.sortingOrder = 0;
    }

    public void stateBarriers(bool state) //Activa / Desactiva los muros.
    {
        barriers.gameObject.SetActive(state);
    }
}





