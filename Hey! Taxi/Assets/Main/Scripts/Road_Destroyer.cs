using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Destroyer : MonoBehaviour
{
    public GameObject Road_Destructýon_Point;
   


    void Start()    
    {
        Road_Destructýon_Point = GameObject.Find("Road_Destructýon_Point");


    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x < Road_Destructýon_Point.transform.position.x)
        {

            //Destroy(gameObject);
            gameObject.SetActive(false);
            

        }
    }
}
