using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float speed;
    private float originPos;
    public float distance;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Astronauta1")
        {
            Destroy(gameObject);
        }
        Debug.Log("hola");
    }
    void Start()
    {
        originPos = gameObject.transform.position.y;
        Debug.Log("Inicia");
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
