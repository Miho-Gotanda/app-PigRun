using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMove : MonoBehaviour
{
    private GameObject move;
    private Camera mainCamera;
    private Vector3 deadPosition;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.move = GameObject.Find("Stage");
        GameObject obj = GameObject.Find("Main Camera");
        mainCamera = obj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //カメラを右に動かす
        float deltaPosition = this.transform.position.x + Time.deltaTime*5.3f;
        move.transform.position = new Vector2(deltaPosition, this.transform.position.y);

        //画面の左を超えたら死亡
        if (player.transform.position.x < deadPos().x)
        {
            SceneManager.LoadScene("DeadScene");
        }

    }

    public Vector3 getScreenTopLeft()
    {
        //画面の左上を取得
        Vector3 topLeft = mainCamera.ScreenToWorldPoint(Vector3.zero);
        //上下反転
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        return topLeft;
    }

    private Vector3 getScreenBottomRight()
    {
        //画面の右下を取得
        Vector3 bottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        //上下反転させる
        bottomRight.Scale(new Vector3(1f, -1f, 1f));
        return bottomRight;
    }

    private Vector3 deadPos()
    {
        deadPosition = new Vector3(getScreenTopLeft().x, getScreenTopLeft().y, 0.0f);
        return deadPosition;
    }
}
