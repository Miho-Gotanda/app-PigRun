using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCotroller : MonoBehaviour
{
    private GameObject deadArea;
   
    // Start is called before the first frame update
    void Start()
    {
        deadArea = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaPosition = this.transform.position.x + Time.deltaTime*5.3f;
        deadArea.transform.position = new Vector3(deltaPosition, this.transform.position.y, 0.0f);

    }

    


}
