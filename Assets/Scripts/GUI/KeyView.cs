using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyView : MonoBehaviour
{
    public Image iconView;

    public SpaceShip spaceShip;

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isTouchingDoor = spaceShip.isTouchingDoor;



        /*Muestra el medidor de combustible si el jugador tiene (o no) el JetPack*/
        if (isTouchingDoor)
        {
            iconView.enabled = true;
        }
        else
        {
            iconView.enabled = false;
        }
    }
}
