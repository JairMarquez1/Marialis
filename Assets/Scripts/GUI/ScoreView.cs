﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public GameObject player;
    public Text gearText;
    public Text lifeText;
    private Movement script;
    // Start is called before the first frame update
    void Awake()
    {
        script = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        gearText.text = script.scoreGear.ToString();
        lifeText.text = Mathf.Clamp(script.life, 0, 100).ToString();
    }
}
