using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    public float bulletSpeed;
    public float bulletLife;

    public GameObject player;
    private Transform playerTrans;

    void Awake() 
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<BoxCollider2D>().isTrigger)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (playerTrans.localScale.x == -1f) 
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
        }
        if (playerTrans.localScale.x == 1f)
        {
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
        }
    }

    void Update()
    {
        Destroy(gameObject, bulletLife);
    }
}