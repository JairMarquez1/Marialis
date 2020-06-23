using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRockLaunch : MonoBehaviour
{
    public Rigidbody2D rock;
    public float forceX;
    public float forceY;
    public float rockLife = 5f;
    public float distance;
    private Transform player;

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       distance = (player.position.x - transform.position.x);
       rock.AddForce(new Vector2(forceX * distance * (0.55f + Random.Range(-.2f,.2f)), forceY),ForceMode2D.Impulse);
    }

    void Update()
    {
        Destroy(gameObject, rockLife);
    }
}
