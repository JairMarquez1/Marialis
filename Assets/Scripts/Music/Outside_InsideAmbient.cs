using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outside_InsideAmbient : MonoBehaviour
{
    /*Volumen*/
    public float volumeMusic;
    public float volumeAmbient;
    public float volumeEffects;

    /*Fuente de audio*/
    AudioSource audioAmbient;

    /*Interacciones*/
    public SpaceShip spaceShip;

    /*Clips de audio*/
    public AudioClip wind_Clip;
    public AudioClip insideShip_Clip;

  
    private void Awake()
    {
        audioAmbient = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioAmbient.Play();
    }


    void Update()
    {
        inside_Outside_Ambient();
    }

    void inside_Outside_Ambient()
    {
        /*Sonido para exteriores e interiores*/
        if (spaceShip.isOpeningDoor == true) /*Si el jugador abre la puerta*/
        {
            if (spaceShip.isInside == true) //Dentro de la nave. (Viento desde interiores).
                audioAmbient.clip = insideShip_Clip;

            if (spaceShip.isInside == false) //Fuera de la nave. (Viento desértico).
                audioAmbient.clip = wind_Clip;
            
            audioAmbient.Play(); 
        }
    }
}
