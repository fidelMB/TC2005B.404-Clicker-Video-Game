using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public ScoreManager scoreManager;

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

    public void OnCharacterClick()
    {
        animator.SetBool("Click", true);
        Debug.Log("Click");
        StartCoroutine(ResetClickAnimation());
    }

    IEnumerator ResetClickAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        animator.SetBool("Click", false);
    }
}
