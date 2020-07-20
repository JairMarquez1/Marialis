using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsEffect : MonoBehaviour
{
    //public GameObject follow;
    //public Camera cameraSize;
    public float speedRotation = 0.1f;
    public Light generalLight;
    public float dayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        dayTime = Mathf.Clamp(Mathf.Abs(transform.rotation.z) * 10 - 1, 1,8);
        generalLight.intensity = dayTime;

        /*Obtiene la posición de la cámara*/
        //float posX = follow.transform.position.x;
        //float posY = follow.transform.position.y;

        /*Obtiene el tamaño de la cámara*/
        //Se divide entre el múltiplo con el que empieza la cámara (variable "Size" del component Camera)
        //float size = cameraSize.orthographicSize / 5f;

        //transform.position = new Vector3(posX, posY -1f, transform.position.z); 
        transform.Rotate(new Vector3(0, 0, 0.1f) * speedRotation);
        //transform.localScale = new Vector3(1f, 1f, 1f) * size; //Se adapta al tamaño de la cámara.
    }
}