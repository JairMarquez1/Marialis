using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public GameObject follow;
    private float posXOriginal;
    private float posYOriginal;

    public float speedX;
    public float speedY;

    public bool ejeX = true;
    public bool ejeY = true;


    private Vector3 lastCameraPosition;
    private Transform cameraTransform;
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    

    void Start()
    {
        posXOriginal = transform.position.x;
        posYOriginal = transform.position.y;
        cameraTransform = follow.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        /*Mueve la posición de la cámara*/
        /*float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;



        if(ejeX == true && ejeY == true)
        {
            transform.position = new Vector3(posX + posXOriginal + (posX * speedX), posY + posYOriginal + (posY * speedY), transform.position.z);
        }

        if(ejeX == true && ejeY == false)
        {
            transform.position = new Vector3(posX + posXOriginal + (posX * speedX), posYOriginal, transform.position.z);
        }

        if (ejeX == false && ejeY == true)
        {
            transform.position = new Vector3(posXOriginal, posY + posYOriginal + (posY * speedY), transform.position.z);
        }*/

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;



    }
}
