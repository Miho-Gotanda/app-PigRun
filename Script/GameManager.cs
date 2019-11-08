using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("HightScore", 0);
        text.text = "HightScore:" + score.ToString(); ;
    }

    // Update is called once per frame
   public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ManualButton()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
