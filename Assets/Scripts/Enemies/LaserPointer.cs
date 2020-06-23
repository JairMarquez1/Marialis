using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    int pruebadeGitHub; //Eliminar linea.
    void Start()
    {
        lineRenderer.enabled = true;
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
        }
    }
}