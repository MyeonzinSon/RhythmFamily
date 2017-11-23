
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    int score1;
    int score2;
    public Text scoreText1;
    public Text scoreText2;
    public GameObject textMover;
    public Slider slider;

    float initTime;
    float startTime;
    float musicLength;
    void Start()
    {
        score1 = 0;
        score2 = 0;
        initTime = Time.time;
        slider.value = 0;
    }
    public void SetTime(float start, float length)
    {
        startTime = start;
        musicLength = length;
    }

    float MusicTime()
    {
        return Time.time - initTime - startTime;
    }
    void Update()
    {
        if (MusicTime() >= 0 && MusicTime() <= musicLength)
        {
            slider.value = MusicTime()/musicLength;
        }
    }
    public void AddScore(Player player, int value, Vector2 pos)
    {
        if(player == Player.p1)
        {
            score1 += value;
            Instantiate(textMover, transform).GetComponent<TextMover>().SetVariables(pos, value);
            scoreText1.text = ""+score1+"";
        }
        else
        {
            score2 += value;
            Instantiate(textMover, transform).GetComponent<TextMover>().SetVariables(pos, value);
            scoreText2.text = ""+score2+"";
        }
    }
}