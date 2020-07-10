using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyView : MonoBehaviour
{
    /*Teclas*/
    public Image iconView_X;
    public Image iconView_Z;
    public Image iconView_Right;
    public Image iconView_Left;
    public Image iconView_Down;
    public Image iconView_Up;

    /*Interacciones*/
    public SpaceShip spaceShip;
    public triggerTutorial phase;


    // Update is called once per frame
    void FixedUpdate()
    {
        bool isTouchingDoor = spaceShip.isTouchingDoor;
        bool isNoob = phase.isNoob;

        if (isNoob)
        {
            iconView_Right.enabled = true;
            iconView_Left.enabled = true;
            iconView_Down.enabled = true;
            iconView_Up.enabled = true;
        }
        else
        {
            iconView_Right.enabled = false;
            iconView_Left.enabled = false;
            iconView_Down.enabled = false;
            iconView_Up.enabled = false;
        }

   


        /*Se muestra si está en un objeto interactivo*/
        if (isTouchingDoor)
            iconView_X.enabled = true;  
        else
            iconView_X.enabled = false;


        
    }
}
