using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public Transform head;
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    private GameManager gameManager;
    //Accesorios (Prefabs)
    public GameObject jetPackAccessory;
    public GameObject gunAccessory;
    public GameObject touching;
    //Estados
    public bool hasGun = false;
    public bool hasJetPack = false;
    public bool touchingAccessory = false;
    public bool touchingGun = false;
    public bool touchingJetPack = false;

    public bool grounded;
    public bool jumping;   
    private bool sneaking;
    private bool flying;
    private bool immunized = false;
    //Atributos
    public float jumpPower = 8f;
    public float jetPackPower = 01.45f;
    public float speed = 500f;
    public float maxVelx = 10f;
    public float maxVely = 10f;
    public int jumpDuration;
    private int jumpcount;               //Valor auxiliar (Sirve como contador)
    private float immunizedcount;         //Valor auxiliar (Sirve como contador)
    private float velx;
    private float vely;
    //private float timeRechargingFuel = 100f;
    public float coolDownAccessory = 0f;
    //Scores
    public int scoreGear;
    public float fuelJetpack = 100f;
    public int life;

    private Rigidbody2D rigibody2d;
    private Animator playerAnimation;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gear")
            scoreGear++;
    }*/
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Accessory")
        {
            touching = collision.gameObject;
            touchingAccessory = true;
            if (collision.gameObject.name == "gun") 
            { 
                touchingGun = true;
                touchingJetPack = false;
            }
            if (collision.gameObject.name == "jetPack")
            {
                touchingJetPack = true;
                touchingGun = false;
            }
            coolDownAccessory = 0f;
        }

        if (collision.gameObject.tag == "Gear")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("1");
            scoreGear++;
            Debug.Log("2");
        }
        /*Tomar accesorios al tocarlos*/
        if (collision.gameObject.tag == "Dangerous")
            damage(1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Accessory")
            touchingAccessory = false;
        {
            if (collision.gameObject.name == "gun")
                touchingGun = false;
            if (collision.gameObject.name == "jetPack")
                touchingJetPack = false;
        }
    }

    private void Awake()
    {
        rigibody2d = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        playerAnimation = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        life = 5;
    }

    void Update()
    {
        //---------------------Movimiento horizontal---------------------
        if (Input.GetKey("left"))
        {
            rigibody2d.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            //gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(1f, 1, 1);
            playerAnimation.SetBool("walking", true);
        }

        if (Input.GetKey("right"))
        {
            rigibody2d.AddForce(new Vector2(speed * Time.deltaTime, 0));
            //gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.localScale = new Vector3(-1f, 1, 1);
            playerAnimation.SetBool("walking", true);
        }
        else if (!Input.GetKey("left"))
        {
            playerAnimation.SetBool("walking", false);
        }
        //-------------------"Desagachamiento" y Salto----------------------
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            //-------Desagacharse-------
            if (sneaking)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(head.position, head.up);
                //Debug.Log(hitInfo.transform.name);
                //lineRenderer.SetPosition(0, firePoint.position);
                //lineRenderer.SetPosition(1, hitInfo.point);
                Debug.Log(hitInfo.collider.gameObject.name);
                if (hitInfo.collider)
                {
                    if (hitInfo.point.y - head.position.y > 0.44f)
                    {
                        speed *= 2f;
                        bulletSpawner.Translate(new Vector3(0f, 0.27f, 0f));
                        playerAnimation.SetBool("sneaking", false);
                        GetComponent<CapsuleCollider2D>().offset = new Vector2(0.07f, -0.02f);
                        GetComponent<CapsuleCollider2D>().size = new Vector2(0.6f, 1.9f);
                        sneaking = false;
                    }
                }

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
        //-----------------------------Agacharse----------------------------
        if (Input.GetKeyDown(KeyCode.DownArrow) && grounded)
        {
            if (!sneaking)
            {
                speed /= 2f;
                bulletSpawner.Translate(new Vector3(0f, -0.27f, 0f));
                playerAnimation.SetBool("sneaking", true);
                GetComponent<CapsuleCollider2D>().offset = new Vector2(0.07f, -0.25f);
                GetComponent<CapsuleCollider2D>().size = new Vector2(0.6f, 1.4f);
                sneaking = true;
            }
        }
        //--------------------------Volar(JetPack)----------------------------
        if (Input.GetKey(KeyCode.Space) && hasJetPack && !sneaking && fuelJetpack > 0)
        {
            rigibody2d.AddForce(Vector2.up * jetPackPower, ForceMode2D.Impulse);
            playerAnimation.SetBool("flying", true);
            flying = true;
        }
        else
        {
            playerAnimation.SetBool("flying", false);
            flying = false;
        }

        //--------------------------Validar animación de accesorios---------------
        if (hasGun)
        {
            playerAnimation.SetBool("withJetPack", false);
            playerAnimation.SetBool("withgun", true);
        }
        else if (hasJetPack)
        {
            playerAnimation.SetBool("withgun", false);
            playerAnimation.SetBool("withJetPack", true);
        }
        else
        {
            playerAnimation.SetBool("withgun", false);
            playerAnimation.SetBool("withJetPack", false);
        }
        //------------------Periodo de inmunidad al recibir daño--------------
        if (immunized)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            immunizedcount -= Time.deltaTime;
            //Debug.Log(immunizedcount);
            if (immunizedcount < 0) 
                { 
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                immunized = false;
                }
    }


        JetPack();
        PlayerShooting();
        
        takeDropAccessories();

    }

    void FixedUpdate()
    {

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

        velx = rigibody2d.velocity[0];
        vely = rigibody2d.velocity[1];
        //Trunca la velocidad del personaje para que nunca supere ciertos valores.
        rigibody2d.velocity = new Vector2(Mathf.Clamp(velx, -maxVelx, maxVelx), Mathf.Clamp(vely, -9.8f, maxVely));

    }


    public void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1") && hasGun)
        {
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        }
    }


    public void JetPack()
    {
        float usageRate = 120f; //Tasa de uso.
        float regenerationRate = 20f; //Tasa de regeneración

        if (flying)
            fuelJetpack -= usageRate * Time.deltaTime; //Reduce el combustible del Jetpack.

        if (!flying)
            fuelJetpack += regenerationRate * Time.deltaTime; //Regenera el combustible del JetPack.

        if (flying && fuelJetpack <= 0) //Aumenta ligeramente el tiempo de generación cuando el combustible se agota por completo.
            fuelJetpack = -10f;

        fuelJetpack = Mathf.Clamp(fuelJetpack, -10f, 100f);
    }

    public void takeDropAccessories()
    {
        float coolDownRate = 300f;
        if (!touchingAccessory)
            coolDownAccessory += coolDownRate * Time.deltaTime; //Regenera enfriamiento para tomar un arma.
        coolDownAccessory = Mathf.Clamp(coolDownAccessory, 0, 100f);

        /*1. Genera el accesorio que se quita. (Prefab)
          2. Se le asigna un nombre al prefab generado.
          3. El personaje convierte el accesorio en "falso".*/

        if (Input.GetKeyDown(KeyCode.Z))
        { 
            //Dropea el antiguo accesorio si es que tenía alguno.

            if (hasGun /*&& coolDownAccessory == 100f*/)
            {
                playerAnimation.SetBool("withgun", false);
                GameObject gun = Instantiate(gunAccessory, transform.position, transform.rotation); //1
                gun.name = "gun"; //2
                hasGun = false; //3
            }
            else if (hasJetPack /*&& coolDownAccessory == 100f*/)
            {
                playerAnimation.SetBool("withJetPack", false);
                GameObject jetPack = Instantiate(jetPackAccessory, transform.position, transform.rotation);
                jetPack.name = "jetPack";
                hasJetPack = false;
            }

            //Actualiza los atributos de posesión de accesorios.
            if (touchingGun)
            {
                hasGun = true;
                hasJetPack = false;
                Destroy(touching);
            }
            else if (touchingJetPack)
            {
                hasJetPack = true;
                hasGun = false;
                Destroy(touching);
            }
            
        }
    }
        
    public void set_ground(bool boolean)
    {
        grounded = boolean;
    }

    public void damage(int damquantity)
    {
        if (!immunized)
        {
            life-= damquantity;
            immunized = true;
            immunizedcount = 0.5f;
            if (life < 1)
            {
                //Time.timeScale = 0f;
                playerAnimation.SetBool("sneaking", true);
                gameManager.GameOver = true;
                //gameManager.RestartGame();
                Destroy(gameObject);
            }

        }
    }
}
