using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gearPrefab;
    private GameObject player;
    private Rigidbody2D rigidbody;
    public float visionRadius;
    public float toCloseRadius;
    public string direccion;
    public bool onVisionRadius = false;
    public float health = 3f;
    public float speed = 1f;
    public bool stopped;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void LaunchProjectile()
    {
            Instantiate(projectile, new Vector2(transform.position.x,transform.position.y+1), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
            {
                Instantiate(gearPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "NotShootable" || collision.gameObject.tag == "Player")
            stopped = true;
    }

    private void Movement()
    {
        //Disparo
        float dist = Vector3.Distance(player.transform.position, transform.position);
        //Campo de vision
        if (dist < visionRadius)
        {
            gameObject.GetComponent<Animator>().SetBool("shooting", true);
            onVisionRadius = true;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("shooting", false);
            onVisionRadius = false;
        }
        //Direccion de movimiento
        if (transform.position.x > player.transform.position.x)
        {
            if (direccion != "Izq") stopped = false;
            direccion = "Izq";
            transform.localScale = new Vector3(-1f, 1, 1); 
        }
        else
        {
            if (direccion != "Der") stopped = false;
            direccion = "Der";
            transform.localScale = new Vector3(1f, 1, 1);
        }
        //Movimiento
        if (!stopped && dist < toCloseRadius)
        {
            //Izquierda
            if (direccion == "Izq")
                transform.Translate(speed * Time.deltaTime, 0, 0);
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));  
            //Derecha
            else
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0f));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius); //Debug -> Muestra gráficamente el rango de visión del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, toCloseRadius);
    }

}