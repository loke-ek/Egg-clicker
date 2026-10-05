using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator buttonAnimator;

    void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        buttonAnimator.SetTrigger("click");
    }
}