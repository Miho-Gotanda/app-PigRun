using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeadScore : MonoBehaviour
{
    public Text maxScore;
    public Text newScore;
    public Text coinText;

    private int hightScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score1", 0);
        int coinscore = score / 5;
        coinText.text = coinscore.ToString();
        newScore.text =score.ToString();

        hightScore = PlayerPrefs.GetInt("HightScore", 0);
        maxScore.text = "HightScore:" + hightScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > hightScore)
        {
            hightScore = score;
            PlayerPrefs.SetInt("HightScore", score);
            maxScore.text = "HightScore:" + hightScore.ToString();
        }
    }
}
