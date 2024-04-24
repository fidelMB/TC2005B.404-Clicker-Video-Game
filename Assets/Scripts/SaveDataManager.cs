using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] private ScoreManager ScoreManager; // Referencia al ScoreManager para poder acceder a las variables dentro de él

    public GameProgressData gameProgressData = new GameProgressData();

    private void SaveData()
    {
        string jsonSaveData = JsonUtility.ToJson(gameProgressData);
        string filePath = Application.persistentDataPath + "/saveData.json";
        System.IO.File.WriteAllText(filePath, jsonSaveData);
        Debug.Log("Progreso guardado en: " + filePath);
    }


}

[System.Serializable]
public class GameProgressData
{
    // Valores del score
    public int neoCoins;
    public int autoClickValue;
    public int clickPowerValue;

    // Valores de la tienda de mejoras
    public int upgradeCostMouse;
    public float upgradeIncrementMouse;
    public int upgradeLevelMouse;

    public int upgradeCostChair;
    public float upgradeIncrementChair;
    public int upgradeLevelChair;

    public int upgradeCostGPU;
    public float upgradeIncrementGPU;
    public int upgradeLevelGPU;

    public int upgradeCostGPT;
    public float upgradeIncrementGPT;
    public int upgradeLevelGPT;
}