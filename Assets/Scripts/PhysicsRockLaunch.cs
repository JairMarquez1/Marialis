using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRockLaunch : MonoBehaviour
{
    public Rigidbody2D rock;
    public float forceX;
    public float forceY;

    void Start()
    {
       rock.AddForce(transform.up * 8f,ForceMode2D.Impulse);
    }

}
