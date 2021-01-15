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
    private float distance;
    private float distanceY;
    private Transform player;
    private Animator rockAnimation;
    public float randomDifx = 0.2f;
    public float randomDify = 2f;

    void Start()
    {
       rockRB = gameObject.GetComponent<Rigidbody2D>();
       rockAnimation = gameObject.GetComponent<Animator>();
       player = GameObject.FindGameObjectWithTag("Player").transform;
       distance = (player.position.x - transform.position.x);
       distanceY = (player.position.y - transform.position.y);
       rockRB.AddForce(new Vector2(forceX*distance + distance*Random.Range(-randomDifx,randomDifx) + 0.5f , (distanceY * 0.5f) + forceY + Random.Range(-randomDify,randomDify)),ForceMode2D.Impulse);
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
            //Debug.Log(collision.gameObject.name);
            //Debug.Log(gameObject.name);
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
                try
                {
                    if (!collision.gameObject.GetComponent<TilemapCollider2D>().isTrigger && (collision.gameObject.layer!=2))
                    {
                        gameObject.transform.rotation = Quaternion.identity;
                        rockAnimation.SetBool("explode", true);
                        rockRB.velocity = new Vector2(0, 0);
                        rockRB.gravityScale = 0;
                        rockLife = 0.5f;
                        gameObject.tag = "Untagged";
                    }
                }
                catch (MissingComponentException) {; }
            }
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
