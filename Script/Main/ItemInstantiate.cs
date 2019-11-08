using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiate : MonoBehaviour
{
    public GameObject stagePrefab;
    public GameObject coinPrefab;
    public GameObject firePrefab;
    public GameObject[] coinPosition;
    public GameObject[] firePosition;

    private int randamCoinPos;
    private int randamFirePos;
    // Start is called before the first frame update
    void Start()
    {
        randamCoinPos = Random.Range(0, 4);
        randamFirePos = Random.Range(0, 4);

        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            var coin=Instantiate(coinPrefab, coinPosition[randamCoinPos].transform.position, Quaternion.identity);
            var fire=Instantiate(firePrefab, firePosition[randamFirePos].transform.position, Quaternion.identity);

            coin.transform.SetParent(stagePrefab.transform, true);
            fire.transform.SetParent(stagePrefab.transform, true);
        }
    }

    // Update is called once per frame
   
}
