using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    public bool hasGun = false;
    public float jumpPower = 8f;
    private bool jump;
    private bool grounded;
    private bool sneaking;
    public float speed = 500f;

    private Rigidbody2D rigibody2d;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "gun")
        {
            hasGun = true;
        }
        else if (collision.transform.tag == "ground")
        {
            grounded = true;
        }

        // Start is called before the first frame update
    }
 

    private void Awake()
    {
        rigibody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
        rigibody2d.AddForce(new Vector2(-speed * Time.deltaTime, 0));
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<Animator>().SetBool("walking",true);
         }
        if (Input.GetKey("right")) {
        rigibody2d.AddForce(new Vector2(speed * Time.deltaTime, 0));
        gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        gameObject.GetComponent<Animator>().SetBool("walking",true);
        }
        else if (!Input.GetKey("left")){
        gameObject.GetComponent<Animator>().SetBool("walking",false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            if (sneaking)
            {
                speed *= 2f;
                bulletSpawner.Translate(new Vector3(0f, 0.27f, 0f));
                gameObject.GetComponent<Animator>().SetBool("sneaking", false);
                GetComponent<BoxCollider2D>().offset = new Vector2(0.07f, -0.02f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.6f, 1.86f);
                sneaking = false;
            }
            else
            {
                jump = true;
                grounded = false;
            }
        }
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

            PlayerShooting();
        if (hasGun)
        {
            gameObject.GetComponent<Animator>().SetBool("withgun", true);
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rigibody2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }



    public void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1") && hasGun)
        {
            Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        }
    }
}



