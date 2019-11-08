using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public Text ScoreText;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreChange();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score += 5;
            Destroy(collision.gameObject);
            ScoreChange();
        }

        if (collision.gameObject.tag == "Fire")
        {
            SceneManager.LoadScene("DeadScene");
        }
    }

    private void ScoreChange()
    {
        ScoreText.text = "Score:" + score;
        PlayerPrefs.SetInt("Score1", score);
    }
}
