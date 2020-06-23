using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    public float visionRadius;
    public float speed;

    GameObject player;
    Vector3 initialPosition;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position; //Rango de visión del enemigo. 

        transform.position = Vector3.MoveTowards(transform.position, target, speed); //Se mueve hacia el jugador.
        Debug.DrawLine(transform.position, target, Color.green); //Debug -> Muestra gráficamente el rango de visión del enemigo
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius); //Debug -> Muestra gráficamente el rango de visión del enemigo
    }

}
