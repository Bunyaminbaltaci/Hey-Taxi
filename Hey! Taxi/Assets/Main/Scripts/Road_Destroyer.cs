using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Destroyer : MonoBehaviour
{
    public GameObject Road_Destruct�on_Point;
   


    void Start()    
    {
        Road_Destruct�on_Point = GameObject.Find("Road_Destruct�on_Point");


    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x < Road_Destruct�on_Point.transform.position.x)
        {

            //Destroy(gameObject);
            gameObject.SetActive(false);
            

        }
    }
}
