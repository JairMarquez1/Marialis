using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    public GameObject rock;
    public Transform follow;
    
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2, 1);
    }

    void FixedUpdate()
    {
        float angle = Angle(follow.transform.position, transform.position) - 90f;
        angle = Mathf.Clamp(angle, -90f, 110f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }



    void LaunchProjectile()
    {
        Instantiate(rock, transform.position, transform.rotation);
    }


    /*Calcula el ángulo entre 2 puntos*/
    static float Angle(Vector3 P1, Vector3 P2) 
    {
        Vector3 vector = P1 - P2; 
        vector.Normalize(); //Convierte los valores en base a 1.

        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        return angle;
    }
}
