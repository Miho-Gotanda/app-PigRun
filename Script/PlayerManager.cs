using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//ログインしたプレイヤーの情報を保持する為のクラス
public class PlayerManager : MonoBehaviour
{
    public UserState userState;
    private int game_score;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        userState = new UserState();
        game_score = 0;
    }

    public void SetUserName(string name) => userState.name = name;
    public void SetUserScore(int score) => userState.score = score;
    public void SetGameScore(int score) => game_score = score;
    public string GetUserName() { return userState.name; }
    public int GetUserScore() { return userState.score; }
    public int GetGameScore() { return game_score; }
    

}

[System.Serializable]
public class UserState
{
    public string name;
    public int score;
}
