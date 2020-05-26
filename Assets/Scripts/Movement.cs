using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{

    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    //Accesorios (Prefabs)
    public GameObject jetPackAccessory;
    public GameObject gunAccessory;
    //Estados
    public bool hasGun = false;
    public bool hasJetPack = false;
    public bool touchingAccessory = false;
    public bool touchingGun = false;
    public bool touchingJetPack = false;

    private bool jumping;
    private bool grounded;
    private bool sneaking;
    private bool flying;
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
    private float timeRechargingFuel = 100f;
    public float coolDownAccessory = 0f;
    //Scores
    public int scoreGear;
    public float fuelJetpack = 100f;




    private Rigidbody2D rigibody2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gear")
        {
            scoreGear++;
        }
        else if (collision.transform.tag == "ground")
        {
            grounded = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Accessory")
            touchingAccessory = true;

        coolDownAccessory = 0f;

        /*Tomar accesorios al tocarlos*/
        if (collision.gameObject.name == "gun")
            touchingGun = true;
        if (collision.gameObject.name == "jetPack")
            touchingJetPack = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Accessory")
            touchingAccessory = false;

        if (collision.gameObject.name == "gun")
            touchingGun = false;
        if (collision.gameObject.name == "jetPack")
            touchingJetPack = false;
    }


    private void Awake()
    {
        rigibody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //---------------------Movimiento horizontal---------------------
        if (Input.GetKey("left"))
        {
            rigibody2d.AddForce(new Vector2(-speed * Time.deltaTime, 0));
            //gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(1f, 1, 1);
            gameObject.GetComponent<Animator>().SetBool("walking", true);
        }

        if (Input.GetKey("right"))
        {
            rigibody2d.AddForce(new Vector2(speed * Time.deltaTime, 0));
            //gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.localScale = new Vector3(-1f, 1, 1);
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
        if (Input.GetKey(KeyCode.Space) && hasJetPack && !sneaking && fuelJetpack > 0)
        {
            rigibody2d.AddForce(Vector2.up * jetPackPower, ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("flying", true);
            flying = true;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("flying", false);
            flying = false;
        }
        JetPack();

        PlayerShooting();
        if (hasGun)
        {
            gameObject.GetComponent<Animator>().SetBool("withgun", true);
        }
        if (hasJetPack)
        {
            gameObject.GetComponent<Animator>().SetBool("withJetPack", true);
        }

        dropAccesories();
        
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
        //Debug.Log(rigibody2d.velocity);
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

        fuelJetpack = Mathf.Clamp(fuelJetpack, -10, 100);
    } 



    public void dropAccesories()
    {
        float coolDownRate = 300f;

        if (!touchingAccessory)
            coolDownAccessory += coolDownRate * Time.deltaTime; //Regenera enfriamiento para tomar un arma.

        coolDownAccessory = Mathf.Clamp(coolDownAccessory, 0, 100f);

        /*Cada if tiene una serie de pasos
         1. Genera el accesorio que se quita. (Prefab)
         2. Le da genera un nombre al prefab generado.
         3. El personaje convierte el accesorio en "falso".
         */

        if (hasGun && Input.GetKeyDown(KeyCode.Z) && coolDownAccessory == 100f)
        {
           GameObject gun = Instantiate(gunAccessory, transform.position, transform.rotation); //1
           gun.name = "gun"; //2
           hasGun = false; //3
        }

        if(hasJetPack && Input.GetKeyDown(KeyCode.Z) && coolDownAccessory == 100f)
        {
            GameObject jetPack = Instantiate(jetPackAccessory, transform.position, transform.rotation);
            jetPack.name = "jetPack";
            hasJetPack = false;
        }
    }
}
