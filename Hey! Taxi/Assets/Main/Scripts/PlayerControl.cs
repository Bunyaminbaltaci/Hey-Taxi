using UnityEngine;
using DG.Tweening;
using Heytaxi;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
    public class PlayerControl : MonoBehaviour
    {
        private float endZpos = 0;
        private Rigidbody myBody;
        public float speed;
        private Collider colliderComponent;                         
    private void OnEnable()
    {
        InputManager.instance.SwipeTranslate += ActionOnSwipe;
    }
    private void OnDisable()
        {
            InputManager.instance.SwipeTranslate -= ActionOnSwipe;

        }
        
       private void Start()
        {
            myBody = gameObject.GetComponent<Rigidbody>();
            myBody.isKinematic = false;
            myBody.useGravity = false;
            colliderComponent = GetComponent<Collider>();

            SpawnVehicle(GameManager.singeton.currentCarIndex);



    }


    public void GameStarted()
        {
            InputManager.instance.SwipeTranslate += ActionOnSwipe;


        }

        
        void Update()
        {
       
        if (GameManager.singeton.gameStatus == GameStatus.PLAYING)
        {
            
            transform.position += (transform.forward * speed * Time.deltaTime);
           // myBody.velocity = new Vector3(speed, myBody.velocity.y, myBody.velocity.z);
          


        }

        else if (GameManager.singeton.gameStatus==GameStatus.NONE)
        {

        }
         

    }
    public void SpawnVehicle(int currentindex)
    {

        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }

        GameObject child = Instantiate(LevelManager.instance.Carsprefabs[currentindex],transform);


    }
    void ActionOnSwipe(SwipeType swipeType)
        {
       

        if (GameManager.singeton.gameStatus==GameStatus.PLAYING)
            {
                
                switch (swipeType)
                {

                    case SwipeType.RIGHT:
                        endZpos = transform.position.z + 5;
                        break;
                    case SwipeType.LEFT:
                        endZpos = transform.position.z - 5;
                        break;

                }
         
                endZpos = Mathf.Clamp(endZpos, -5, 5);
                transform.DOMoveZ(endZpos, 0.5f);
            }
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag=="Enemy")
            {
                if (GameManager.singeton.gameStatus==GameStatus.PLAYING)
                {

                    GameManager.singeton.gameStatus = GameStatus.FAILED;

                    DOTween.Kill(this);
                
                GetComponent<Collider>().isTrigger = false;
                myBody.isKinematic = false;
                myBody.useGravity = true;
                UIManager.instance.GameOver();
                myBody.AddForce(Random.insideUnitCircle.normalized * 100f);
                Camera.main.transform.DOShakePosition(1f,Random.insideUnitCircle.normalized,5,10,false,true).OnComplete
                    (
                    () =>UIManager.instance.GameOver()
                    );// camera shaking
                 
            }
            }
          

    }
   
}

