using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


namespace Heytaxi
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        [SerializeField] private GameObject mainMenuPanel, gameMenuPanel, gameOverPanel, shopmenu;
        [SerializeField] private Text distanceText;
        [SerializeField] private GameObject camera;
        [SerializeField] private TextMeshProUGUI kasa;
        private PlayerControl playercontroller;
        public Text DistanceText { get { return distanceText; } }
        private void Start()
        {
            GameManager.singeton.gameStatus = GameStatus.NONE;
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        public void PlayButton()
        {
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(true);
            GameManager.singeton.gameStatus = GameStatus.PLAYING;
            // playercontroller.GameStarted();           
        }
        public void RetryButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }
        public void shop()
        {
            kasa.text = SaveManager.instance.money.ToString("F1");
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(false);
            camera.SetActive(false);
            shopmenu.SetActive(true);

        }
        public void exit()
        {

            Application.Quit();
        }

    }
}