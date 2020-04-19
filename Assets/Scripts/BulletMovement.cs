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
    int pruebadeGitHub;

    // Start is called before the first frame update
    void Awake() 
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag != "NotShootable")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
        if (playerTrans.localRotation.y != 0)
        {
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
        }
        else
        {
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
        }
    }

    // Update iscalled once per frame
    void Update()
    {
        Destroy(gameObject, bulletLife);
    }
}