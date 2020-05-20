using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public GameObject player;
    public Text gearText;
    public Movement script;
    // Start is called before the first frame update
    void Awake()
    {
        script = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        gearText.text = script.scoreGear.ToString();
    }
}
