using UnityEngine;
using DG.Tweening;
using Heytaxi;
using System.Collections;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Rigidbody))]
    public class PlayerControl : MonoBehaviour
    {
        private float endZpos = 0;
        private Rigidbody myBody;
        public float speed;
        private Collider colliderComponent;
        public Text taksimetretxt;
        public TextMeshProUGUI cointect ;
        public float taksimetre;
        public bool baslangýc;


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
            cointect.text = SaveManager.instance.money.ToString("F1");
           



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
            if (baslangýc==true)
            {
                taksimetre += 0.01f;
                taksimetretxt.text = taksimetre.ToString("F1");
                
            }
          


        }

        else if (GameManager.singeton.gameStatus==GameStatus.NONE)
        {

        }
         

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

