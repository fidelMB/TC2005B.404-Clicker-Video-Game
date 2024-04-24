using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private SaveDataManager SaveDataManager; // Referencia al SaveDataManager para poder acceder a las variables dentro de él
    public TMP_Text neoCoinsText; // Texto que muestra las monedas
    public float neoCoins; // Monedas
    public float clickValue; // Valor de las monedas ganadas por click
    public float autoClickValue; // Valor de las monedas ganadas por segundo

    // Start is called before the first frame update
    void Start()
    {
        // Estos valores están de ejemplo, pero se van a cargar desde el archivo de guardado de la base de datos
        neoCoins = 200;
        clickValue = 1;
        autoClickValue = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza el texto de las monedas
        neoCoinsText.text = "<sprite name=neo_coin>" + (int)neoCoins;

        // Neo coins ganadas por segundo en el autoclick
        neoCoins += autoClickValue * Time.deltaTime;

        // Guarda el progreso del juego
        SaveDataManager.gameProgressData.neoCoins = (int)neoCoins;
        SaveDataManager.gameProgressData.autoClickValue = (int)autoClickValue;
        SaveDataManager.gameProgressData.clickPowerValue = (int)clickValue;
    }

    // Método para añadir monedas al hacer click
    public void Hit()
    {
        neoCoins += clickValue;
    }
}
