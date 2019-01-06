using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlaform;
    public Transform generationPoint;
    private float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private CoinGenerator theCoinGenarator_up;
    private CoinGenerator theCoinGenarator_down;
    public float randomCoinThreshold_up;
    public float randomCoinThreshold_down;

    void Start()
    {
        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        theCoinGenarator_up = FindObjectOfType<CoinGenerator>();
        theCoinGenarator_down = FindObjectOfType<CoinGenerator>();
    }

    void Update()
    {

        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCoinThreshold_up) {
                theCoinGenarator_up.SpawnCoins(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomCoinThreshold_down) {
                theCoinGenarator_down.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}
