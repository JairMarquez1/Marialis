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
    public triggerTutorial sides;
    public triggerTutorial sneak;
    //public triggerTutorial...

    public bool pressKeyToMoveSides;
    public bool pressKeyToSneak;

    private void Start()
    {
        iconView_Down.enabled = false;
        iconView_Left.enabled = false;
        iconView_Right.enabled = false;
        iconView_Up.enabled = false;
        iconView_X.enabled = false;
        iconView_Z.enabled = false;
    }


    void FixedUpdate()
    {
        PressKeyToMoveToTheSides();
        PressKeyToSneak();
        //...
    }

    private void PressKeyToMoveToTheSides()
    {
        pressKeyToMoveSides = sides.isInside;

        if (pressKeyToMoveSides == true)
        {
            iconView_Right.enabled = true;
            iconView_Left.enabled = true;
        }
        else
        {
            iconView_Right.enabled = false;
            iconView_Left.enabled = false;
        }
    }

    private void PressKeyToSneak()
    {
        pressKeyToSneak = sneak.isInside;

        if (pressKeyToSneak == true)
            iconView_Down.enabled = true;       
        else
            iconView_Down.enabled = false;
        
    }
}


