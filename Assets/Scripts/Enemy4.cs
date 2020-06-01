using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    public GameObject gearPrefab;
    public float visionRadius;
    public float toCloseRadius;
    public bool onVisionRadius = false;
    public float health = 3f;
    public float speed = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            gameObject.GetComponent<Animator>().SetBool("shooting", true);
            onVisionRadius = true;
        }
        else
        {
            onVisionRadius = false;
            gameObject.GetComponent<Animator>().SetBool("shooting", false);
        }
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
            if (dist < toCloseRadius) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        }
        else
        {
            transform.localScale = new Vector3(1f, 1, 1);
            if (dist < toCloseRadius) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        }
    }
    void LaunchProjectile()
    {
            Instantiate(projectile, transform.position, transform.rotation);
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius); //Debug -> Muestra gráficamente el rango de visión del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, toCloseRadius);
    }

}