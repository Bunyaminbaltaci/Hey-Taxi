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
            SaveManager.instance.Load();
            SpawnVehicle(SaveManager.instance.currentCostume);
           
        }
        public void SpawnVehicle(int currentindex)
        {

            if (player.transform.childCount > 0)
            {
                Destroy(player.transform.GetChild(0).gameObject);
            }

            Instantiate(instance.Carsprefabs[currentindex], player.gameObject.transform);


        }


    }
}