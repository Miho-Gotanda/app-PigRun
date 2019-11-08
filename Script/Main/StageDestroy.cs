using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroy : MonoBehaviour
{
    private StageMove Stage;
    private GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        Stage = GameObject.Find("Stage").GetComponent<StageMove>();
        point = this.transform.Find("point").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage.getScreenTopLeft().x-5f> point.transform.position.x)
        {
            Destroy(this.gameObject);
            
        }
    }
}
