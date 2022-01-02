
using UnityEngine;
using UnityEngine.UI;
using Heytaxi;

public class CostumeSelection : MonoBehaviour
{
    [Header ("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button NextButton;

    [Header("Back/Buy Buttons")]
    [SerializeField] private Button Buy;
    [SerializeField] private Button select;
    [SerializeField] private Text PriceText;

    [Header("Costume Attributes")]
    [SerializeField]private int[] CostumePrice;
    private int currentcostume;

    private void Start()
    {
        currentcostume = SaveManager.instance.currentCostume;

        SelectCostume(currentcostume);
    }
    private void SelectCostume(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i==_index);
        }
        UpdateUI();
       
    }
    private void UpdateUI()
    {
        if (SaveManager.instance.CostumeUnlocked[currentcostume])
        {
            Buy.gameObject.SetActive(false);
            select.gameObject.SetActive(true);
        }
        else
        {
            Buy.gameObject.SetActive(true);
            select.gameObject.SetActive(false);
            PriceText.text = CostumePrice[currentcostume] + "";
          
        }


    }
    private void Update()
    {
        if (Buy.gameObject.activeInHierarchy)
        {
            // parasi yetiyormu interactable metodu etkileþime geçile bilir anlamýnda
            Buy.interactable = (SaveManager.instance.money >= CostumePrice[currentcostume]);
        }
    }
        
    public void ChangeCostume(int _change)
    {
        currentcostume += _change;
        if (currentcostume> transform.childCount-1)
        {
            currentcostume = 0;
        }
        else if (currentcostume<0)
        {
            currentcostume = transform.childCount - 1;
        }
       
        SelectCostume(currentcostume);

    }
    public void _select()
    {
        Debug.Log(currentcostume);
        SaveManager.instance.currentCostume = currentcostume;
        LevelManager.instance.SpawnVehicle(currentcostume);
        SaveManager.instance.Save();

    }
    public void BuyCostume()
    {
        SaveManager.instance.money -= CostumePrice[currentcostume];
        SaveManager.instance.CostumeUnlocked[currentcostume] = true;
        SaveManager.instance.Save();

        UpdateUI();
    }

  
}
