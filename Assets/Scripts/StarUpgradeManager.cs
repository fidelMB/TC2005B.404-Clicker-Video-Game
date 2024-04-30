using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StarUpgradeManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager; // Reference to ScoreManager
    public GameObject upgradeGameObject;
    public Sprite[] upgradeSprites;
    public int upgradeCost = 10; // Cost of the upgrade
    public float upgradeIncrement = 2.0f; // How much the upgrade adds
    public string upgradeName; // Name of the upgrade
    public int upgradeLevel = 0; // Current level of the upgrade
    public float upgradeIncrementAdder = 0.5f; // Additional increment per upgrade level
    public TMP_Text upgradeBuyButtonText; // Button text for purchasing the upgrade
    public TMP_Text upgradeNameLevelAndNextLevelText; // Text showing the name of the upgrade, current level, and next level increment
    public string upgradeType; // Type of upgrade, either "Monitor" or "Chair"
    private int maxLevel; // Maximum level of the upgrade
    private string upgradeText;

    void Start()
    {
        maxLevel = upgradeType == "Auto Click" ? 2 : 4; // Max level is 3 for Monitor and 5 for Chair
        upgradeBuyButtonText.text = "<sprite name=neo_stars>" + FormatNumber(upgradeCost);
        UpdateUpgradeText();
    }

    public void BuyUpgrade()
    {
        if (scoreManager.neoStars >= upgradeCost && upgradeLevel < maxLevel)
        {
            scoreManager.neoStars -= upgradeCost;
            upgradeCost = (int)(upgradeCost * 2.5f);
            upgradeLevel++;
            ApplyUpgradeEffect();

            UpdateUpgradeText();

            if (upgradeLevel == maxLevel)
            {
                upgradeBuyButtonText.text = "MAX";
                GetComponent<Button>().interactable = false; // Disable button at max level
            }
            else
            {
                upgradeBuyButtonText.text = "<sprite name=neo_stars>" + FormatNumber(upgradeCost);
            }
        }
    }

    private void ApplyUpgradeEffect()
    {
        if (upgradeType == "Auto Click")
        {
            scoreManager.autoClickValue *= 2;
            UpdateSprite(upgradeGameObject, upgradeSprites, upgradeLevel);
        }
        else if (upgradeType == "Click Power")
        {
            scoreManager.clickValue *= 2;
            UpdateSprite(upgradeGameObject, upgradeSprites, upgradeLevel);
        }
        upgradeIncrement += upgradeIncrementAdder; // Increase the increment for the next level
    }

    private void UpdateUpgradeText()
    {
        upgradeNameLevelAndNextLevelText.text = $"{upgradeName} Lvl {upgradeLevel} / {maxLevel}\nLvl Up: x{FormatNumber(upgradeIncrement)} {upgradeType}";
    }

    private void UpdateSprite(GameObject gameObject, Sprite[] sprites, int level)
    {
        if (sprites != null && level >= 0 && level < sprites.Length)
        {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprites[level];
            }
        }
    }

    private string FormatNumber(float number)
    {
        if (number >= 1000000)
        {
            return (number / 1000000f).ToString("0.0") + "M";
        }
        if (number >= 1000)
        {
            return (number / 1000f).ToString("0.0") + "k";
        }
        return Mathf.RoundToInt(number).ToString();
    }
}
 