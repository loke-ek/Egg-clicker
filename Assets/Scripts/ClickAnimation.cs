using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Click()
    {
       animator.SetTrigger("Click");
        Debug.Log("Hej");
    }
}
