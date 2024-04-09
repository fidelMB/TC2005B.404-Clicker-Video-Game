using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    // Referencia al ScoreManager para poder acceder a las variables dentro de él
    [SerializeField] private ScoreManager ScoreManager;
    public int upgradeCost;
    public float upgradeValue;
    public string upgradeName;
    public int upgradeLevel;
    public float upgradeValueIncrementAdder;
    public Text nameLvlCoinsPerSecText;
    public Text upgradeCostButtonText;

    // Start is called before the first frame update
    void Start()
    {
        nameLvlCoinsPerSecText.text = upgradeName + " Lvl " + upgradeLevel + "\nSiguiente mejora: " + upgradeValue + " Neo Coins /s";
        upgradeCostButtonText.text = "COMPRAR " + upgradeCost + " Neo Coins";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método para comprar un upgrade
    public void BuyUpgrade()
    {
        // Si el coste del upgrade es menor o igual a las monedas que tenemos
        if (ScoreManager.neoCoins >= upgradeCost)
        {


            // Actualizar monedas, valor del autoclick, coste del upgrade y nivel del upgrade
            ScoreManager.neoCoins -= upgradeCost;
            upgradeCost = (int)(upgradeCost * 2.5f);
            upgradeLevel++;
            upgradeValue = upgradeValue + upgradeValueIncrementAdder;
            ScoreManager.autoClickValue += upgradeValue;


            // Actualizar texto del botón, nivel y 
            upgradeCostButtonText.text = "COMPRAR " + upgradeCost + " Neo Coins";
            // Actualizar texto de monedas por segundo
            nameLvlCoinsPerSecText.text = upgradeName + " Lvl " + upgradeLevel + "\nSiguiente mejora: " + upgradeValue + " Neo Coins /s";
        }
    }
}
