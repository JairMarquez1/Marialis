using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public int health = 2;
    public float speed = -1;
    public bool MoveRight = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveRight = !MoveRight;
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
                Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
