using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script controla el laser del Enemigo 1, se genera un raycast desde el firePoint que es el objeto LaserSpawner y se dibuja el LineRenderer de la trayectoria del laser.
public class LaserPointer : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    private Movement script;
    void Start()
    {
        lineRenderer.enabled = true;
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        { 
            //Debug.Log(hitInfo.transform.name);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            //Si hace contacto con el jugador, llama al método damage de la clase Movement.
            if (hitInfo.collider.tag == "Player")
                script.damage(1);

        }
    }
}