using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Generator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    public GameObject destroyer;

    //Arka Arkaya Gelememe Beta,
    private int platform_tutucu;

    //private float platformWidth;

    public float distanceWidthMin;
    public float distanceWidthMax;

    //public GameObject[] platformlar;
    private int platformSelector;
    private float[] platformWidths;

    public Road_Pooler[] theObjectPools;

    void Start()
    {
        platform_tutucu = -1;
        //platformWidth = platform.GetComponent<BoxCollider>().size.z;
        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider>().size.x;

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {

            //distanceBetween = Random.Range(distanceWidthMin, distanceWidthMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            if (platform_tutucu != platformSelector)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y,
                transform.position.z);
                    

                //Instantiate(/*platform*/ platformlar[platformSelector], transform.position, transform.rotation);

                GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);
                transform.position = new Vector3(transform.position.x + platformWidths[platformSelector], transform.position.y,
                transform.position.z);

            }
            platform_tutucu = platformSelector;
        }
    }
}
