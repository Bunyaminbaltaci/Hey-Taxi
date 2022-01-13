using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heytaxi;

public class cutScene : MonoBehaviour
{
    public GameObject cutscenecamera;
    public GameObject maincamera;
    public GameObject player;
    public GameObject charac;


    
    
    void Start()
    {
        player = GameObject.Find("Player");
        maincamera = GameObject.Find("Main Camera");
        

      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player" && GameManager.singeton.gameStatus!=GameStatus.FAILED)
        {
            charac.SetActive(true);
            StartCoroutine(cutsceneenum());

        }
    }
     IEnumerator cutsceneenum()
    {
        SaveManager.instance.money += player.GetComponent<PlayerControl>().taksimetre;
        player.GetComponent<PlayerControl>().cointect.text = SaveManager.instance.money.ToString("F1");
        SaveManager.instance.Save();

        player.GetComponent<PlayerControl>().taksimetre = 0;
        player.GetComponent<PlayerControl>().baslangýc = true;
        GameManager.singeton.gameStatus = GameStatus.NONE;
        //player.GetComponent<PlayerControl>().enabled=false;
        
        maincamera.SetActive(false);
        cutscenecamera.SetActive(true);
        charac.GetComponent<Animator>().SetTrigger("yuru");
        yield return new WaitForSecondsRealtime(1.5f);
        charac.SetActive(false);
       // yield return new WaitForSecondsRealtime(2);
        cutscenecamera.SetActive(false);
        maincamera.SetActive(true);
        //player.GetComponent<PlayerControl>().enabled = true;
        GameManager.singeton.gameStatus = GameStatus.PLAYING;


    }
}
