using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRockLaunch : MonoBehaviour
{
    public Rigidbody2D rock;
    public float forceX;
    public float forceY;
    public float rockLife = 5f;

    void Start()
    {
       rock.AddForce(transform.up * 8f,ForceMode2D.Impulse);
    }

    void Update()
    {
        Destroy(gameObject, rockLife);
    }
}
