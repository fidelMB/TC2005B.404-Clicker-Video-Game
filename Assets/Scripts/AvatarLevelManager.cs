using UnityEngine;
using UnityEngine.UI;

public class AvatarLevelManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SaveDataManager saveDataManager;
    public Sprite[] levelSprites;
    public int buttonLevelThreshold;
    public GameObject spriteDisplayObject;
    public GameObject interactableButton;
    private Button cosmeticButton;

    // Definir limites para cada nivel
    private int[] levelThresholds = { 0, 1000, 10000, 100000, 1000000, 10000000 };
    private int currentLevel;

    void Start()
    {
        cosmeticButton = GetComponent<Button>();
        cosmeticButton.interactable = false;
        UpdateButtonInteractable(CalculateLevel());
    }

    void Update()
    {
        int newLevel = CalculateLevel();
        if (newLevel != currentLevel)
        {
            currentLevel = newLevel;
            UpdateButtonInteractable(currentLevel);
            UpdateSprite(currentLevel);
        }
    }

    int CalculateLevel()
    {
        // Find out the current level based on total coins earned
        int level = 0;
        while (level < levelThresholds.Length &&
               scoreManager.totalCoinsEarned >= levelThresholds[level])
        {
            level++;
        }
        return level;
    }

    void UpdateButtonInteractable(int level)
    {
        // Make button interactable if the level is greater than or equal to the threshold
        if (cosmeticButton != null)
        {
            cosmeticButton.interactable = level >= buttonLevelThreshold;
        }
    }

    void UpdateSprite(int level)
    {
        // Update the sprite for the new level
        if (spriteDisplayObject != null && level >= 0 && level < levelSprites.Length)
        {
            spriteDisplayObject.GetComponent<Image>().sprite = levelSprites[level];
        }
    }
}
