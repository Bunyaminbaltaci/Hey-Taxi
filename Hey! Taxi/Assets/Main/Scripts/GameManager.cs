using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Heytaxi
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager singeton;
       [HideInInspector] public GameStatus gameStatus = GameStatus.NONE;
      public int currentCarIndex;
        private void Awake()
        {
            if (singeton==null)
            {
                singeton = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            
            singeton.currentCarIndex = SaveManager.instance.currentCostume;
        }
    }
}