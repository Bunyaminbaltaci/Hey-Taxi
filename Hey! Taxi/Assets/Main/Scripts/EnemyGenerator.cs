using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heytaxi;
public class EnemyGenerator : MonoBehaviour
{
    private float[] enemySpawnposition = new float[3];
  
  
    private int EnemyTutucu;
    private int EnemySelector;
    public Enemy_Pooler[] theObjectPools;
    public Transform EnemySpawnpoint;
        



    private void Start()
    {
        EnemyTutucu = -1;
        enemySpawnposition[0] = -5.0f;
        enemySpawnposition[1] = 0.0f;
        enemySpawnposition[2] = 5.0f;
    }
    private void Update()
    {
        if (GameManager.singeton.gameStatus == GameStatus.PLAYING)
        {
            if (transform.position.x < EnemySpawnpoint.position.x)
            {
                EnemySelector = Random.Range(0, theObjectPools.Length);

                if (EnemyTutucu != EnemySelector)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y,
                    transform.position.z);


                    //Instantiate(/*platform*/ platformlar[platformSelector], transform.position, transform.rotation);

                    GameObject enemy = theObjectPools[Random.Range(0, theObjectPools.Length)].GetPooledObject();

                    enemy.transform.position = new Vector3(transform.position.x, transform.position.y, (enemySpawnposition[Random.Range(0, enemySpawnposition.Length)]));

                    enemy.SetActive(true);

                    transform.position = new Vector3(transform.position.x +35f, 0,
                    0);
                }
                EnemyTutucu = EnemySelector;
            }
        }

    }
   


}