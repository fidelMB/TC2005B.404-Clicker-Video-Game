using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private ScoreManager ScoreManager; // Referencia al ScoreManager para poder acceder a las variables dentro de él
    [SerializeField] private SaveDataManager SaveDataManager; // Referencia al SaveDataManager para poder acceder a las variables dentro de él
    public int upgradeCost; // Coste del upgrade
    public float upgradeIncrement; // Incremento del upgrade, monedas por segundo/click aumentadas
    public string upgradeName; // Nombre del upgrade
    public int upgradeLevel; // Nivel actual del upgrade
    public float upgradeIncrementAdder; // Valor que se añade al incremento del upgrade cada vez que se sube de nivel
    public TMP_Text upgradeBuyButtonText; // Texto del botón de compra del upgrade
    public TMP_Text upagradeNameLevelAndNextLevelText; // Texto que muestra el nombre del upgrade, el nivel actual y el incremento del siguiente nivel
    public string upgradeType; // Tipo de upgrade, si es de "Auto Click" o de "Click Power"
    

    //public string upgradeCostCoin;

    // Start is called before the first frame update
    void Start()
    {
        if (upgradeName == "Mouse")
        {
            upgradeIncrement = SaveDataManager.gameProgressData.upgradeIncrementMouse;
            upgradeCost = SaveDataManager.gameProgressData.upgradeCostMouse;
            upgradeLevel = SaveDataManager.gameProgressData.upgradeLevelMouse;
        }
        else if (upgradeName == "Silla")
        {
            upgradeIncrement = SaveDataManager.gameProgressData.upgradeIncrementChair;
            upgradeCost = SaveDataManager.gameProgressData.upgradeCostChair;
            upgradeLevel = SaveDataManager.gameProgressData.upgradeLevelChair;
        }
        else if (upgradeName == "GPU")
        {
            upgradeIncrement = SaveDataManager.gameProgressData.upgradeIncrementGPU;
            upgradeCost = SaveDataManager.gameProgressData.upgradeCostGPU;
            upgradeLevel = SaveDataManager.gameProgressData.upgradeLevelGPU;
        }
        else if (upgradeName == "GPT")
        {
            upgradeIncrement = SaveDataManager.gameProgressData.upgradeIncrementGPT;
            upgradeCost = SaveDataManager.gameProgressData.upgradeCostGPT;
            upgradeLevel = SaveDataManager.gameProgressData.upgradeLevelGPT;
        }

        // Si el tipo de upgrade es de autoclick se muestra el incremento en monedas por segundo,
        // si es de click se muestra el incremento en monedas por click
        if (upgradeType == "Auto Click")
        {
            upagradeNameLevelAndNextLevelText.text = upgradeName + " Lvl " + upgradeLevel + "\nLvl Up: " + upgradeIncrement + "<sprite name=neo_coin>/s";
        }
        else if (upgradeType == "Click Power")
        {
            upagradeNameLevelAndNextLevelText.text = upgradeName + " Lvl " + upgradeLevel + "\nLvl Up: " + upgradeIncrement + "<sprite name=neo_coin>/click";
        }
        
        // Actualizar texto del botón de compra
        upgradeBuyButtonText.text = "<sprite name=neo_coin>" + upgradeCost;
    }

    // Método para comprar un upgrade
    public void BuyUpgrade()
    {
        // Si el coste del upgrade es menor o igual a las monedas que tenemos se compra el upgrade
        if (ScoreManager.neoCoins >= upgradeCost)
        {

            // Si es autoclick, se actualizan las monedas por segundo, si es click se actualiza el valor del click
            // También cambia el texto de nombre, nivel y siguiente nivel
            if (upgradeType == "Auto Click")
            {
                // Actualizar monedas, valor del autoclick, coste del upgrade y nivel del upgrade
                ScoreManager.neoCoins -= upgradeCost;
                upgradeCost = (int)(upgradeCost * 2.5f);
                upgradeLevel++;
                ScoreManager.autoClickValue += upgradeIncrement;
                upgradeIncrement = upgradeIncrement + upgradeIncrementAdder;

                // Actualizar texto de nombre, nivel y siguiente nivel
                upagradeNameLevelAndNextLevelText.text = upgradeName + " Lvl " + upgradeLevel + "\nLvl Up: " + upgradeIncrement + "<sprite name=neo_coin>/s";
            }
            else if (upgradeType == "Click Power")
            {
                // Actualizar monedas, valor del autoclick, coste del upgrade y nivel del upgrade
                ScoreManager.neoCoins -= upgradeCost;
                upgradeCost = (int)(upgradeCost * 2.5f);
                upgradeLevel++;
                upgradeIncrement = upgradeIncrement + upgradeIncrementAdder;
                ScoreManager.clickValue = upgradeIncrement;

                // Actualizar texto de nombre, nivel y siguiente nivel
                upagradeNameLevelAndNextLevelText.text = upgradeName + " Lvl " + upgradeLevel + "\nLvl Up: "  + upgradeIncrement + "<sprite name=neo_coin>/click";
            }

            // Actualizar texto del botón
            upgradeBuyButtonText.text = "<sprite name=neo_coin>" + upgradeCost;

            // Actualizar el nivel del upgrade en el archivo de guardado
            if (upgradeName == "Mouse")
            {
                SaveDataManager.gameProgressData.upgradeIncrementMouse = upgradeIncrement;
                SaveDataManager.gameProgressData.upgradeCostMouse = upgradeCost;
                SaveDataManager.gameProgressData.upgradeLevelMouse = upgradeLevel;
            }
            else if (upgradeName == "Silla")
            {
                SaveDataManager.gameProgressData.upgradeIncrementChair = upgradeIncrement;
                SaveDataManager.gameProgressData.upgradeCostChair = upgradeCost;
                SaveDataManager.gameProgressData.upgradeLevelChair = upgradeLevel;
            }
            else if (upgradeName == "GPU")
            {
                SaveDataManager.gameProgressData.upgradeIncrementGPU = upgradeIncrement;
                SaveDataManager.gameProgressData.upgradeCostGPU = upgradeCost;
                SaveDataManager.gameProgressData.upgradeLevelGPU = upgradeLevel;
            }
            else if (upgradeName == "GPT")
            {
                SaveDataManager.gameProgressData.upgradeIncrementGPT = upgradeIncrement;
                SaveDataManager.gameProgressData.upgradeCostGPT = upgradeCost;
                SaveDataManager.gameProgressData.upgradeLevelGPT = upgradeLevel;
            }
            
        }
    }
}
