using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float speed;
    private float originPos;
    public float distance;
    public bool autoPickUp;
    private bool physics = true;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (autoPickUp)
            Destroy(gameObject);
        }
        else if (physics)
        {
            physics = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.transform.Translate(0, 0.3f, 0);
            this.enabled = true;
        }

    }
    void Start()
    {
        originPos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((speed > 0) && (gameObject.transform.position.y < originPos + distance))
        {
            gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else if (speed > 0)
        {
            speed = -speed;
        }
        else if (gameObject.transform.position.y > originPos - distance)
        {
            gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else
        {
            speed = -speed;
        }
    }

}
