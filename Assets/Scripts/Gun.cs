﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public bool touchingPlayer;
    private Movement player;

    private void Awake()
    {
        touchingPlayer = false;
        player = GameObject.Find("Astronauta1").GetComponent<Movement>();
    }


    /*Cuando está tocando el accesorio*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronauta1")
            touchingPlayer = true;
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.transform.Translate(0, 0.3f, 0);
            gameObject.GetComponent<FloatingItem>().enabled = true;
        }
    }

    /*Cuando NO está tocando el accesorio*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Astronauta1")
            touchingPlayer = false;
    }

    private void FixedUpdate()
    {
        if (touchingPlayer && Input.GetKeyDown(KeyCode.Z))
        {
            //Poner en "true" el accesorio que le pertenece al Script
            player.hasGun = true; 

            /*Poner EL RESTO de los accesorios en false*/
            player.hasJetPack = false;
            //accesory2 = false;
            //accesory3 = false;
            //... = false;
            
            Destroy(gameObject); //Simula que el personaje toma el objeto.
        }
        
    }
}
