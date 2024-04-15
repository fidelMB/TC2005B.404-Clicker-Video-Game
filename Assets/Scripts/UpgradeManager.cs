using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private ScoreManager ScoreManager; // Referencia al ScoreManager para poder acceder a las variables dentro de él
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
            
        }
    }
}
