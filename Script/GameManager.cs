using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }
    void Start()
    {
        text.text = "HightScore:" + playerManager.userState.score;
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
