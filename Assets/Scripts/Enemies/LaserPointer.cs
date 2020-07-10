using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    private Movement script;
    int pruebadeGitHub; //Eliminar linea.
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
            if (hitInfo.collider.tag == "Player")
                script.damage(1);

        }
    }
}