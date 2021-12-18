using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heytaxi;
namespace enemy
{
    public class EnemyController : MonoBehaviour
    {
        public float moveSpeed;
        public GameObject play;

        private void Start()
        {
            play = GameObject.Find("Destroypoint");

        }

        private void Update()
        {
            if (GameManager.singeton.gameStatus== GameStatus.PLAYING)
            {
                transform.position += (transform.forward * moveSpeed * Time.deltaTime);
               
            }
          
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag=="Destroyer")
            {
                gameObject.SetActive(false);
            }
        }

    }
}