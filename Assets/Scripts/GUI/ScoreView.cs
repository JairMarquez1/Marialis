using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text gearText;
    public Text lifeText;
    private Movement script;
    public Image life;
    // Start is called before the first frame update
    void Awake()
    {
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        gearText.text = script.scoreGear.ToString();
        lifeText.text = Mathf.Clamp(script.life, 0, 100).ToString();
        life.rectTransform.sizeDelta = new Vector2(script.life * 45f, 40);
    }
}
