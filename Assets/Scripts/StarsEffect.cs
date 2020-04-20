using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsEffect : MonoBehaviour
{
    public GameObject follow;
    public float speedRotation = 0.1f;
    //public Light dayTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //dayTime.intensity = transform.rotation.z;

        /*Mueve la posición de la cámara*/
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3(posX, posY -4f, transform.position.z);
        transform.Rotate(new Vector3(0, 0, 0.1f) * speedRotation);   
    }
}