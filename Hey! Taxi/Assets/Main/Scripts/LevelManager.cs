using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heytaxi
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance { get; private set; }
        public Transform generationPoint;

        private float movespeed;    
        public GameObject[] Carsprefabs;
        public GameObject[] EnemyCarPrefab;
        [SerializeField]
        private GameObject player;
       

        private void Awake()
        {
            if (instance==null)
            {
                instance = this;
            
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {

        }
     

    }
}