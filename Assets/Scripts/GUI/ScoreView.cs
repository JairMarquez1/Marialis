using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Movement scriptMovement;

    public Text gearText;
    public Text lifeText;
    public Text timeText;
    public Image life;
    public float time = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        scriptMovement= GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        gearText.text = scriptMovement.scoreGear.ToString();
        lifeText.text = Mathf.Clamp(scriptMovement.life, 0, 100).ToString();
        life.rectTransform.sizeDelta = new Vector2(scriptMovement.life * 45f, 40);
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");
    }


}
