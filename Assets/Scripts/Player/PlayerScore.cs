using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int maxMultiplier;

    int score;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI multiplierText;
    int scoreMultiplier;
    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreMultiplier = 1;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        multiplierText = GameObject.Find("Multiplier").GetComponent<TextMeshProUGUI>();
        RenderScore();
    }

    // Update is called once per frame
    public void AddScore(int addScore,int addMultiplier)
    {
        
        score += addScore * scoreMultiplier;
        if (scoreMultiplier < maxMultiplier)
        {
            scoreMultiplier += addMultiplier;
        }
        RenderScore();
    }

    private void RenderScore()
    {
        scoreText.text = score.ToString();
        multiplierText.text = "*" + scoreMultiplier.ToString();
    }

    public void ResetMultiplier()
    {
        scoreMultiplier = 1;
        RenderScore();
    }
}
