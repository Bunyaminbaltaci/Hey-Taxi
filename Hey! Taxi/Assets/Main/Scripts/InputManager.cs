using System;
using UnityEngine;



namespace Heytaxi
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;

        private Vector2 startPos, endPos;
        private Vector2 difference;
        private float swipeThreshold = 0.15f;
        public SwipeType swipeType = SwipeType.NONE;
        private float swipeTimeLimit = 0.25f;
        private float startTime, endTime;
        public Action<SwipeType> SwipeTranslate;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = endPos = Input.mousePosition;
                startTime = endTime = Time.time;
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                endTime = Time.time;
                if (endTime - startTime <= swipeTimeLimit) // süre kontrolü hareket iptali için 
                {
                    DetectSwipe();
                }
            }
        }

        private void DetectSwipe()
        {
            swipeType = SwipeType.NONE;
            difference = endPos - startPos;
            if (difference.magnitude > swipeThreshold * Screen.width)
            {
                if (difference.x > 0) //sað kaydýrma
                {
            
                    swipeType = SwipeType.RIGHT;
                }
                else if (difference.x < 0) //sol kaydýrma
                {
                   

                    swipeType = SwipeType.LEFT;
                }

            }
            SwipeTranslate(swipeType);
        }

    }
}
