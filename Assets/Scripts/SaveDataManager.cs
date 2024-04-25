using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private ScoreManager ScoreManager; // Referencia al ScoreManager para poder acceder a las variables dentro de él
    [SerializeField] private UpgradeManager UpgradeManagerMouse;
    [SerializeField] private UpgradeManager UpgradeManagerCriptogranja;
    [SerializeField] private UpgradeManager UpgradeManagerGPU;
    [SerializeField] private UpgradeManager UpgradeManagerGPT;

    private void Start()
    {
        StartCoroutine(GetSaveData("1"));
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(GetSaveData("1"));
        }

    }

    private void SaveData()
    {
        GameProgressData gameProgressData = new GameProgressData
        {
            neoCoins = ScoreManager.neoCoins,
            autoClickValue = ScoreManager.autoClickValue,
            clickPowerValue = ScoreManager.clickValue,

            upgradeCostMouse = UpgradeManagerMouse.upgradeCost,
            upgradeIncrementMouse = UpgradeManagerMouse.upgradeIncrement,
            upgradeLevelMouse = UpgradeManagerMouse.upgradeLevel,

            upgradeCostCriptogranja = UpgradeManagerCriptogranja.upgradeCost,
            upgradeIncrementCriptogranja = UpgradeManagerCriptogranja.upgradeIncrement,
            upgradeLevelCriptogranja = UpgradeManagerCriptogranja.upgradeLevel,

            upgradeCostGPU = UpgradeManagerGPU.upgradeCost,
            upgradeIncrementGPU = UpgradeManagerGPU.upgradeIncrement,
            upgradeLevelGPU = UpgradeManagerGPU.upgradeLevel,

            upgradeCostGPT = UpgradeManagerGPT.upgradeCost,
            upgradeIncrementGPT = UpgradeManagerGPT.upgradeIncrement,
            upgradeLevelGPT = UpgradeManagerGPT.upgradeLevel
        };

        dataPutRequest dataPutRequest = new dataPutRequest
        {
            jsonSaveData = JsonUtility.ToJson(gameProgressData),
            id_user = 1,
            coins = (int)ScoreManager.neoCoins,
            stars = 0
        };

        string jsonData = JsonUtility.ToJson(dataPutRequest);
        
        StartCoroutine(PutSaveData(jsonData));

    }

    private IEnumerator PutSaveData(string jsonData)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Put("http://localhost:5000/save-data", jsonData);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error: {webRequest.error}");
        }
        else
        {
            Debug.Log("Data saved successfully");
        }
    }

    IEnumerator GetSaveData(string user_id)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost:5000/save-data/" + user_id))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Error al obtener save data: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    

                    string jsonSaveData = webRequest.downloadHandler.text;
                    jsonSaveData = jsonSaveData.Substring(1, jsonSaveData.Length - 2);

                    JObject jsonData = JObject.Parse(jsonSaveData);
                    string datos_guardado = jsonData["datos_guardado"].ToString();

                    GameProgressData saveData = JsonConvert.DeserializeObject<GameProgressData>(datos_guardado);

                    ScoreManager.neoCoins = saveData.neoCoins;
                    ScoreManager.autoClickValue = saveData.autoClickValue;
                    ScoreManager.clickValue = saveData.clickPowerValue;

                    UpgradeManagerMouse.upgradeCost = saveData.upgradeCostMouse;
                    UpgradeManagerMouse.upgradeIncrement = saveData.upgradeIncrementMouse;
                    UpgradeManagerMouse.upgradeLevel = saveData.upgradeLevelMouse;

                    UpgradeManagerCriptogranja.upgradeCost = saveData.upgradeCostCriptogranja;
                    UpgradeManagerCriptogranja.upgradeIncrement = saveData.upgradeIncrementCriptogranja;
                    UpgradeManagerCriptogranja.upgradeLevel = saveData.upgradeLevelCriptogranja;

                    UpgradeManagerGPU.upgradeCost = saveData.upgradeCostGPU;
                    UpgradeManagerGPU.upgradeIncrement = saveData.upgradeIncrementGPU;
                    UpgradeManagerGPU.upgradeLevel = saveData.upgradeLevelGPU;

                    UpgradeManagerGPT.upgradeCost = saveData.upgradeCostGPT;
                    UpgradeManagerGPT.upgradeIncrement = saveData.upgradeIncrementGPT;
                    UpgradeManagerGPT.upgradeLevel = saveData.upgradeLevelGPT;

                    break;
            }
        }
    }

    private class GameProgressData
    {
        // Valores del score
        public float neoCoins;
        public float autoClickValue;
        public float clickPowerValue;

        // Valores de la tienda de mejoras
        public int upgradeCostMouse;
        public float upgradeIncrementMouse;
        public int upgradeLevelMouse;

        public int upgradeCostCriptogranja;
        public float upgradeIncrementCriptogranja;
        public int upgradeLevelCriptogranja;

        public int upgradeCostGPU;
        public float upgradeIncrementGPU;
        public int upgradeLevelGPU;

        public int upgradeCostGPT;
        public float upgradeIncrementGPT;
        public int upgradeLevelGPT;
    }

    private class dataPutRequest
    {
        public string jsonSaveData;
        public int id_user;
        public int coins;
        public int stars;
    }

}