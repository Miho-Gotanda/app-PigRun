using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private GameObject error_text=null;
    [SerializeField]
    private GameObject name_error = null;
    [SerializeField]
    private GameObject null_error = null;
    [SerializeField]
    private GameObject check_error = null;
    [SerializeField]
    private Text name_text=null;
    [SerializeField]
    private PlayerManager playerManager = null; 
    [SerializeField]
    private string m_URL="http://192.168.1.16/login.php";
    [SerializeField]
    private string m_URL_Create = "http://192.168.1.16/insert.php";
    //ログインボタンが押された際に実行
    public void OnLoginClick()
    {
        StartCoroutine(OnSend(m_URL,0));

    }

    //新規登録ボタンが押された際に実行
    public void OnCreateClick()
    {
        StartCoroutine(OnSend(m_URL_Create,1));
    }

    IEnumerator OnSend(string url,int buttonN)
    {
        var name = name_text.text;
        //Nameを入力しなかった場合エラーメッセージを表示して終了
        if (name == "")
        {
            switch (buttonN)
            {
                case 0:
                    if (null_error.activeSelf) null_error.SetActive(false);
                    if (name_error.activeSelf) name_error.SetActive(false);
                    error_text.SetActive(true);
                    yield break;
                case 1:
                    if (error_text.activeSelf) error_text.SetActive(false);
                    if (name_error.activeSelf) name_error.SetActive(false);
                    null_error.SetActive(true);
                    yield break;
            }
        }
        //入力されたデータをJSONに変換
        playerManager.SetUserName(name);
        var json = JsonUtility.ToJson(playerManager.userState);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //webRequestオブジェクトをPOST送信形式で用意、受信用オブジェクト作成
        UnityWebRequest webRequest =new UnityWebRequest(url, "POST");
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        webRequest.downloadHandler =(DownloadHandler) new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        //URLに接続、結果が返るまで待機
        yield return webRequest.SendWebRequest();
        //エラーチェック
        if (webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            if (webRequest.downloadHandler.text == "false")
            {
                switch (buttonN)
                {
                    case 0:
                        error_text.SetActive(false);
                        name_error.SetActive(true);
                        break;
                    case 1:
                        if (null_error.activeSelf) null_error.SetActive(false);
                        check_error.SetActive(true);
                        break;
                }
            }
            else
            {
                playerManager.userState = JsonUtility.FromJson<UserState>(webRequest.downloadHandler.text);
                //シーン遷移処理
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}

