using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackDeploy : MonoBehaviour
{
    public GameObject jetPackPrefab;
    public triggerTutorial collision;
    private bool firstTimeInside;

    private void Start()
    {
        firstTimeInside = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && firstTimeInside == true)
        {
            float x = transform.position.x - 4f;
            float y = transform.position.y + 9f;

            GameObject jetPack = Instantiate(jetPackPrefab, new Vector2(x, y), transform.rotation);
            jetPack.name = "jetPack";

            firstTimeInside = false;
        }
            
    }

}
