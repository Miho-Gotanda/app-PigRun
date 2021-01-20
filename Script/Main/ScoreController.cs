using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    private int score=0;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerManager.SetGameScore(0);
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
        playerManager.SetGameScore(score);
    }
}
