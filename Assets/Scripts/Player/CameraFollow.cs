using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject follow;
    //public Vector2 minCamPos, maxCamPos;
    //public float cameraResize = 2;
    public float smoothspeed = 0.125f;
    public Vector3 offset;
    public Vector3 velocity;
    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector3 desiredPosition = follow.transform.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothspeed);
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothedPosition;


    }



   /* void FixedUpdate()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y; 

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(2.5f + posY/cameraResize ,minCamPos.y,maxCamPos.y),
            transform.position.z
            );
        */
        /*
        Cambia el tamaño de la camara en relación a la posición en el eje "Y" del jugador, creando el efecto de alejamiento de la camara.
       
        En y = 0 el tamaño de la camara es igual a 7, al cambiar las coordenadas de el jugador se le sumará al tamaño de la camara
        la coordenada "Y" del jugador divida entre el cameraResize. 

        (Un cameraResize más alto significa un alejamiento de la camara más suave)
        */
        //gameObject.GetComponent<Camera>().orthographicSize = 5f + posY / cameraResize;
            
    //}
}
