using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public GameObject gearPrefab;
    public int health = 2;
    public float speed = -1;
    public bool MoveRight;
    public Transform firePoint;

    void Start()
    {
        //Se define su dirección de movimiento inicial y la rotación del firePoint.
        if (transform.localScale.x < 0)
        {
            MoveRight = true;
            firePoint.transform.Rotate(0, 0, 180);
        }
        else
            MoveRight = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            //Si choca contra algo que no sea el jugador, cambia de direccion su movimiento.
            MoveRight = !MoveRight;
            firePoint.transform.Rotate(0, 0, 180);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
            {
                Instantiate(gearPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
    }


    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1f, 1, 1);
        }
    }
}
