
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    int score1;
    int score2;
    public Text scoreText1;
    public Text scoreText2;
    public GameObject textMover;
    public Slider slider;
    public Text winner;
    public Text spacebar;
    bool isFinished;

    float initTime;
    float startTime;
    float musicLength;
    void Start()
    {
        MusicPlayer.StopMusic();
        winner.gameObject.active = false;
        spacebar.gameObject.active = false;
        isFinished = false;
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
        if (!isFinished && (MusicTime() >= 0 && MusicTime() <= musicLength))
        {
            slider.value = MusicTime()/musicLength;
        }
        else if(!isFinished && MusicTime() >= musicLength)
        {
            CheckWinner();
        }  
        else if(isFinished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneMover.MoveSceneStatic("StartScene");
            }
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
    void CheckWinner()
    {
        if(score1 > score2)
        {
            winner.text = "왼쪽의 승리!";
            winner.color = new Color(1,0,0,1);
        }
        else if (score1 < score2)
        {
            winner.text  = "오른쪽의 승리!";
            winner.color = new Color(0,0,1,1);
        }
        else
        {
            winner.text = "무승부!";
            winner.color = new Color(1,0,1,1);
        }
        winner.gameObject.active = true;
        spacebar.gameObject.active = true;
        isFinished = true;
    }
}