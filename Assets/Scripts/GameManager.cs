using UnityEngine;

public class GameManager : MonoBehaviour{
    int score1;
    int score2;
    void Start()
    {
        score1 = 0;
        score2 = 0;
    }
    public void AddScore(Player player, int value)
    {
        if(player == Player.p1)
        {
            score1 += value;
            Debug.Log("Player1 Score : "+score1 + ", "+value);
        }
        else
        {
            score2 += value;
            Debug.Log("Player2 Score : "+score2);
        }
    }
}