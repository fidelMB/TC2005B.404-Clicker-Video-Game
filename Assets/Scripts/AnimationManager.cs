using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private ScoreManager scoreManager;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (scoreManager.autoClickValue > 0)
        {
            animator.SetBool("autoClick", true);
        }
    }
}
