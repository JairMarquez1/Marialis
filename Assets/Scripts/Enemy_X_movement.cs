using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_x_movement : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
       
    }
}
