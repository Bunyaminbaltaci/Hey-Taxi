using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDest : MonoBehaviour
{
    public GameObject destroyer;

    void Start()
    {
        destroyer = GameObject.Find("Destroypoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyer.transform.position.x)
        {

            //Destroy(gameObject);
            gameObject.SetActive(false);


        }

    }
}
