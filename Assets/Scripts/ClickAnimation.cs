using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickAnimation : MonoBehaviour
{
    private Animator animator;
    // Reference to the button component
    public Button yourButton;

    void Start()
    {
        animator = GetComponent<Animator>();
        // Add listener to the button's onClick event
        yourButton.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        StartCoroutine(TimerAnimationClick());
    }

    IEnumerator TimerAnimationClick()
    {
        animator.SetBool("click", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("click", false);
    }
}
