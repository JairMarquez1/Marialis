using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class PhysicsRockLaunch : MonoBehaviour
{
    private Rigidbody2D rockRB;
    public float forceX;
    public float forceY;
    public float rockLife = 5f;
    public float distance;
    private Transform player;
    private Animator rockAnimation;
    public float aux = 0.55f;

    void Start()
    {
       rockRB = gameObject.GetComponent<Rigidbody2D>();
       rockAnimation = gameObject.GetComponent<Animator>();
       player = GameObject.FindGameObjectWithTag("Player").transform;
       distance = (player.position.x - transform.position.x);
       rockRB.AddForce(new Vector2(forceX * distance * (aux + Random.Range(-.2f,.2f)), forceY),ForceMode2D.Impulse);
    }

    void Update()
    {
        rockLife -= Time.deltaTime;
        //Debug.Log(rockLife);
        if (rockLife < 0)
        {
            rockAnimation.SetBool("explode", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != gameObject.name)
        {
            //Time.timeScale = 0.2f;
            Debug.Log(collision.gameObject.name);
            Debug.Log(gameObject.name);
            try
            {
                if (!collision.gameObject.GetComponent<BoxCollider2D>().isTrigger)
                {
                    rockAnimation.SetBool("explode", true);
                    rockRB.velocity = new Vector2(0, 0);
                    rockRB.gravityScale = 0;
                    rockLife = 0.5f;
                    gameObject.tag = "Untagged";
                }
            }
            catch (MissingComponentException)
            {
                if (!collision.gameObject.GetComponent<TilemapCollider2D>().isTrigger)
                {
                    gameObject.transform.rotation = Quaternion.identity;
                    rockAnimation.SetBool("explode", true);
                    rockRB.velocity = new Vector2(0, 0);
                    rockRB.gravityScale = 0;
                    rockLife = 0.5f;
                    gameObject.tag = "Untagged";
                }
            }
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
