using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    //Estados
    public bool hasGun = false;          
    public bool hasJetPack = false;     
    private bool jumping;               
    private bool grounded;               
    private bool sneaking;   
    //Atributos
    public float jumpPower = 8f;         
    public float jetPackPower = 01.45f;  
    public float speed = 500f;
    public float maxVelx = 10f;
    public float maxVely = 10f;
    public int jumpDuration;
    private int jumpcount;               //Valor auxiliar (Sirve como contador)
    private float velx;
    private float vely;
    
    

    private Rigidbody2D rigibody2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Gun")
        {
            hasGun = true;
        }
        else if(collision.gameObject.name == "JetPack")
        {
            hasJetPack = true;
        }
        else if (collision.transform.tag == "ground")
        {
            grounded = true;
        }
    }
 

    private void Awake()
    {
        rigibody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerShooting();
        if (hasGun)
        {
            gameObject.GetComponent<Animator>().SetBool("withgun", true);
        }
        if (hasJetPack)
        {
            gameObject.GetComponent<Animator>().SetBool("withJetPack", true);
        }
    }

    void FixedUpdate()
    {
        //---------------------Movimiento horizontal---------------------
        if (Input.GetKey("left"))
        {
            rigibody2d.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("walking", true);
        }
        if (Input.GetKey("right"))
        {
            rigibody2d.AddForce(new Vector2(speed * Time.deltaTime, 0));
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            gameObject.GetComponent<Animator>().SetBool("walking", true);
        }
        else if (!Input.GetKey("left"))
        {
            gameObject.GetComponent<Animator>().SetBool("walking", false);
        }
        //-------------------"Desagachamiento" y Salto----------------------
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            //-------Desagacharse-------
            if (sneaking)
            {
                speed *= 2f;
                bulletSpawner.Translate(new Vector3(0f, 0.27f, 0f));
                gameObject.GetComponent<Animator>().SetBool("sneaking", false);
                GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, -0.02f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.86f);
                sneaking = false;
            }
            //-----------Salto----------
            else
            {
                //Jugador entra en estado jumping
                jumping = true;
                //Se inicia el contador
                jumpcount = 0;
                grounded = false;
            }
        }
        if (jumping)
        {
            rigibody2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpcount += 1;
            //El estado jumping dura hasta que el contador llegue a jumpduration
            if (jumpcount > jumpDuration)
            {
                jumping = false;
            }
        }
        //-----------------------------Agacharse----------------------------
        if (Input.GetKeyDown(KeyCode.DownArrow) && grounded)
        {
            if (!sneaking)
            {
                speed /= 2f;
                bulletSpawner.Translate(new Vector3(0f, -0.27f, 0f));
                gameObject.GetComponent<Animator>().SetBool("sneaking", true);
                GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, -0.2f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.48f);
                sneaking = true;
            }
        }
        //--------------------------Volar(JetPack)----------------------------
        if (Input.GetKey(KeyCode.Space) && hasJetPack)
        {
            rigibody2d.AddForce(Vector2.up * jetPackPower, ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("flying", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("flying", false);
        }


        velx = rigibody2d.velocity[0];
        vely = rigibody2d.velocity[1];
        //Trunca la velocidad del personaje para que nunca super ciertos valores.
        rigibody2d.velocity = new Vector2(Mathf.Clamp(velx, -maxVelx, maxVelx), Mathf.Clamp(vely, -9.8f, maxVely));
        //Debug.Log(rigibody2d.velocity);
    }



    public void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1") && hasGun)
        {
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        }
    }
}



