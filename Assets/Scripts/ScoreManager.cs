using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text neoCoinsText; // Texto que muestra las monedas
    public TMP_Text neoCoinsPerSec; // Texto que muestra monedas por segundo
    public TMP_Text neoCoinsPerClick; // Texto que muestra monedas por click
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
        neoCoinsPerSec.text = ((int)autoClickValue).ToString() + "<sprite name=neo_coin>/s";
        neoCoinsPerClick.text = ((int)clickValue).ToString() + "<sprite name=neo_coin>/click";

        // Neo coins ganadas por segundo en el autoclick
        neoCoins += autoClickValue * Time.deltaTime;
    }

    // Método para añadir monedas al hacer click
    public void Hit()
    {
        neoCoins += clickValue;
    }
}
