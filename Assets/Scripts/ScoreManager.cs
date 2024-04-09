using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public Text neoCoinsText;
    public float neoCoins;
    public float clickValue;
    public float autoClickValue;

    // Start is called before the first frame update
    void Start()
    {
        // Estos valores están de ejemplo, pero se van a cargar desde el archivo de guardado de la base de datos
        neoCoins = 0;
        clickValue = 1;
        autoClickValue = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza el texto de las monedas
        neoCoinsText.text = "Neo Coins: " + (int)neoCoins;

        // Neo coins ganadas por segundo en el autoclick
        neoCoins += autoClickValue * Time.deltaTime;


    }

    // Método para añadir monedas al hacer click
    public void Hit()
    {
        neoCoins += clickValue;
    }
}
