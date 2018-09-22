using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;
    public float distanceBetweenCoins;
    private int coinToGenerate;
    System.Random rand = new System.Random();
  
    public void SpawnCoin(Vector3 startPosition)
    {

        coinToGenerate = rand.Next(1, 4);

        switch(coinToGenerate)
        {
            case 1:
                GameObject coin1 = coinPool.GetPooledObject();
                coin1.transform.position = startPosition;
                coin1.SetActive(true);
                break;

            case 2:
                GameObject coin2 = coinPool.GetPooledObject();
                coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
                coin2.SetActive(true);
                break;

            case 3:
                GameObject coin3 = coinPool.GetPooledObject();
                coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
                coin3.SetActive(true);
                break;
        }
    }
}
