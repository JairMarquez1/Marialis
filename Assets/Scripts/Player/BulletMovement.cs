﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D bulletRB;
    public float bulletSpeed;
    public float bulletLife;
    public GameObject player;
    private Transform playerTrans;
    private int direction;
    private Animator bulletAnimation;

    void Awake() 
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
        bulletAnimation = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        //Destroy(gameObject, bulletLife);
        if (playerTrans.localScale.x == -1f) 
        {
            direction = 1;
            bulletRB.velocity = new Vector2(bulletSpeed, bulletRB.velocity.y);
        }
        if (playerTrans.localScale.x == 1f)
        {
            direction = -1;
            bulletRB.velocity = new Vector2(-bulletSpeed, bulletRB.velocity.y);
        }
    }

    void Update()
    {
        bulletLife -= Time.deltaTime;
        if (bulletLife < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (!collision.gameObject.GetComponent<BoxCollider2D>().isTrigger)
            {
                bulletAnimation.SetBool("explode", true);
                bulletRB.velocity = new Vector2(direction * .3f, 0);
                bulletLife = 10f;
            }
        }
        catch (MissingComponentException)
        {
            try
            {
                if (!collision.gameObject.GetComponent<TilemapCollider2D>().isTrigger)
                {
                    bulletAnimation.SetBool("explode", true);
                    bulletRB.velocity = new Vector2(direction * .3f, 0);
                    bulletLife = 10f;
                }
            }
            catch (MissingComponentException) {; }
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}