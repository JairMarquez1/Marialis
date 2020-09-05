using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyView : MonoBehaviour
{
    public GameObject player;
    public GameObject keyboardPosition;

    /*Teclas*/
    public Renderer X_key;
    public Renderer Z_key;
    public Renderer Right_key;
    public Renderer Left_key;
    public Renderer Down_key;
    public Renderer Up_key;

    /*Interacciones*/
    public triggerTutorial sides;
    public triggerTutorial sneak;
    public triggerTutorial jump;

    private bool pressKeyToMoveSides;
    private bool pressKeyToSneak;
    private bool pressKeyToJump;
    private bool pressKeyToTakeAccessory;
    private Movement playerAccessory;

    private void Start()
    {
        pressKeyToMoveSides = false;
        pressKeyToSneak = false;
         playerAccessory = player.GetComponent<Movement>();
    }


    void FixedUpdate()
    {
        positioningKeysOnPlayer();

        PressKeyToMoveToTheSides();
        PressKeyToSneak();
        PressKeyToJump();
        PressKeyToTakeAccessory();
        //...
    }

    private void positioningKeysOnPlayer()
    {
        float x_Keyboard = player.transform.position.x;
        float y_Keyboard = player.transform.position.y + 1.5f;

        keyboardPosition.transform.position = new Vector2(x_Keyboard,y_Keyboard);
    }
    private void pressThisKey(Renderer key) //Resalta el color de la tecla para indicarle al jugador que debe presionarla.
    {
        key.material.color = Color.white;
        key.gameObject.GetComponent<Animator>().enabled = true;
    }
    private void ignoreThisKey(Renderer key) //Opaca el color para darle menos importancia a la tecla.
    {
        key.material.color = new Color(0.7f, 0.7f, 0.7f, 1); //Más oscuro (negro).
        key.gameObject.GetComponent<Animator>().enabled = false;
    }
    private void showArrowKeys(bool arrowKeys)
    {
        if (arrowKeys == true)
        {
            Up_key.enabled = true;
            Down_key.enabled = true;
            Right_key.enabled = true;
            Left_key.enabled= true;
        }
        else
        {
            Up_key.enabled = false;
            Down_key.enabled = false;
            Right_key.enabled = false;
            Left_key.enabled = false;
        }
    }
    private void showActionKeys(bool actionKeys)
    {
        if(actionKeys == true)
        {
            X_key.enabled = true;
            Z_key.enabled= true;
        }
        else
        {
            X_key.enabled = false;
            Z_key.enabled = false;
        }
    }

    private void PressKeyToMoveToTheSides()
    {
        pressKeyToMoveSides = sides.isInside;

        if (pressKeyToMoveSides == true)
        {
            showArrowKeys(true);

            pressThisKey(Left_key);
            pressThisKey(Right_key);

            ignoreThisKey(Up_key);
            ignoreThisKey(Down_key);
        }
        else
        {
            showArrowKeys(false);
        }
    }
    private void PressKeyToSneak()
    {
        pressKeyToSneak = sneak.isInside;

        if (pressKeyToSneak == true)
        {
            showArrowKeys(true);

            pressThisKey(Down_key);

            ignoreThisKey(Right_key);     
            ignoreThisKey(Left_key);
            ignoreThisKey(Up_key);
        }
        else
        {
            showActionKeys(false);
        }
             
        
    }
    private void PressKeyToJump()
    {
        pressKeyToJump = jump.isInside;

        if (pressKeyToJump == true)
        {
            showArrowKeys(true);

            pressThisKey(Up_key);
            

            ignoreThisKey(Right_key);
            ignoreThisKey(Left_key);
            ignoreThisKey(Down_key);
        }
        else
        {
            showActionKeys(false);
        }
    }
    private void PressKeyToTakeAccessory()
    {
        pressKeyToTakeAccessory = playerAccessory.touchingAccessory;

        if(pressKeyToTakeAccessory == true)
        {
            showActionKeys(true);

            pressThisKey(Z_key);
            ignoreThisKey(X_key);
        }
        else
        {
            showActionKeys(false);
        }

    }
}


