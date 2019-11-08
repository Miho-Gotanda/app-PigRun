using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private GameObject back; //生成地点オブジェクト
    private GameObject destination;　//目的地点オブジェクト

    public GameObject[] backGroundPrefab;　//背景オブジェクト
    

    // Start is called before the first frame update
    void Start()
    {
        back = GameObject.Find("Back");
        destination = GameObject.Find("Destination");
    }

    // Update is called once per frame
    void Update()
    {
       

       //backオブジェクトの移動
        float deltaPosition = this.transform.position.x +Time.deltaTime*5.3f;
        back.transform.position = new Vector3(deltaPosition, this.transform.position.y,0.0f);

        var backPositionX = back.transform.position.x;
        var destinationX = destination.transform.position.x;

        int kind = Random.Range(0, 3);
       
        //生成地点オブジェクトが目的地点オブジェクトまできたら背景を生成
        if (backPositionX>=destinationX)
        {
            
            Instantiate(backGroundPrefab[kind], new Vector3(destination.transform.position.x, destination.transform.position.y, 0.0f), Quaternion.identity);
            destination.transform.position = new Vector3(destination.transform.position.x + 19.19f, destination.transform.position.y, 0.0f);
          
        }
        
    }

}
