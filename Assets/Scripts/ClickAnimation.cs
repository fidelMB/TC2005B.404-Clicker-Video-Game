using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickAnimation : MonoBehaviour
{
    // Import Score Manager
    [SerializeField] private ScoreManager scoreManager;

    private Animator animator;
    // Reference to the button component
    public Button yourButton;
    // Get the prefab to spawn
    public GameObject objectToSpawn;



    void Start()
    {
        animator = GetComponent<Animator>();
        // Add listener to the button's onClick event
        yourButton.onClick.AddListener(TaskOnClick);

        InvokeRepeating("SpawnCoinRepeat", 0f, 1f);

    }

    void TaskOnClick()
    {
        // Spawn a coin on click
        SpawnCoin();

        // Start the character growth animation
        StartCoroutine(TimerAnimationClick());
    }

    private void SpawnCoin()
    {
        float CoinSpawnRange = Random.Range(-7, -3);
        Instantiate(objectToSpawn, new Vector3(CoinSpawnRange, 0.5f, 0), transform.rotation);
    }

    private void SpawnCoinRepeat()
    {
        if (scoreManager.autoClickValue > 0)
        {
            SpawnCoin();
        }
    }

    IEnumerator TimerAnimationClick()
    {
        animator.SetBool("click", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("click", false);
    }
}
