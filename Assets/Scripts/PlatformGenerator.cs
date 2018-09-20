using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler objectPool;

    // public GameObject[] platforms;
    public ObjectPooler[] objectPools;

    private int platformSelector;

    private float[] platformWidths;

	// Use this for initialization
	void Start () {

        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[objectPools.Length];

        for(int i = 0; i < objectPools.Length; i++)
        {
            platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            // Add platform width and distance between to X coordinate
            platformSelector = Random.Range(0, objectPools.Length);

            transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

             //Instantiate(platform, transform.position, transform.rotation);
             GameObject newPlatform = objectPools[platformSelector].GetPooledObject();

             newPlatform.transform.position = transform.position;
             newPlatform.transform.rotation = transform.rotation;
             newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}
