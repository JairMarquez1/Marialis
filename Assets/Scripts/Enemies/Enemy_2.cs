using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public GameObject gearPrefab;
    public GameObject player;
    public float health = 2f;
    public float speed = -0.5f;
    public bool MoveRight = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveRight = !MoveRight;
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
    void Start()
    {
        
    }

    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

}

