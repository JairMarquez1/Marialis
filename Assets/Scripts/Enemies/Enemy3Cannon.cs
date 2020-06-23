using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Cannon : MonoBehaviour
{
    public GameObject projectile;
    public Transform follow;
    public Transform couple;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", 1, 4);
    }

    void FixedUpdate()
    {
        Couple();
        float angle = Angle(follow.transform.position, transform.position) - 90f;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }



    void LaunchProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }


    static float Angle(Vector3 P1, Vector3 P2) /*Obtener ángulo*/
    {
        Vector3 vector = P2 - P1; //Obtiene la relación entre ambos objetos.
        vector.Normalize(); //Convierte los valores del vector en unitarios (1).

        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg; //Calcula el ángulo.
        return angle;
    }

    void Couple() /*Acopla el cañón con el sprite*/
    {
        float posX = couple.transform.position.x;
        float posY = couple.transform.position.y;

        transform.position = new Vector2(posX, posY + 1f);
    }
}
