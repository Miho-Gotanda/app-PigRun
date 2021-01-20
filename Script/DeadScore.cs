using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DeadScore : MonoBehaviour
{
    [SerializeField]
    private Text maxScore=null;
    [SerializeField]
    private Text newScore=null;
    [SerializeField]
    private Text coinText=null;

    private string m_URL = "http://192.168.1.16/supdate.php";
    private PlayerManager playerManager;
    private int hightScore;
    private int score;
    // Start is called before the first frame update
    private void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }
    void Start()
    {
        score = playerManager.GetGameScore();
        int coinscore = score / 5;
        coinText.text = coinscore.ToString();
        newScore.text =score.ToString();

        hightScore = playerManager.GetUserScore();
        maxScore.text = "HightScore:" + hightScore.ToString();

        SetHightScore();
        
    }


    private void SetHightScore()
    {
        if (score > hightScore)
        {
            maxScore.text ="HightScore:"+ score.ToString();
            playerManager.SetUserScore(score);
            //サーバに接続し、DB内のスコア値を更新
            StartCoroutine(OnChange(m_URL));
            Debug.Log(playerManager.GetUserScore());
            Debug.Log(playerManager.GetUserName());
        }
    }

    //サーバ接続用コルーチン
    IEnumerator OnChange(string url)
    {
        var json = JsonUtility.ToJson(playerManager.userState);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest unityWeb = new UnityWebRequest(url, "POST");
        unityWeb.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        unityWeb.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        unityWeb.SetRequestHeader("Content-Type", "application/json");

        yield return unityWeb.SendWebRequest();

        if (unityWeb.isNetworkError)
            Debug.Log(unityWeb.error);
        else
        {
            playerManager.userState = JsonUtility.FromJson<UserState>(unityWeb.downloadHandler.text);
        }
    }
}
