using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSounds : MonoBehaviour
{
    /*Fuente de audio*/
    AudioSource SoundEffect;

    /*Interacciones*/
    public SpaceShip spaceShip;

    /*Clips de audio*/
    public AudioClip openingDoor_Clip;


    private void Awake()
    {
        SoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        inside_Outside_Ambient();
    }

    void inside_Outside_Ambient()
    {
        /*Efectos de sonido*/
        if (spaceShip.isOpeningDoor == true) /*Si el jugador abre la puerta*/
        {
            SoundEffect.clip = openingDoor_Clip;
            SoundEffect.Play();
        }
    }
}
