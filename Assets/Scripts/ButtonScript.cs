using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator buttonAnimator;
    [SerializeField] EggSpawnScript spawnScript;

    void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(spawnScript.spawnedEggs.Count >= 1)
        {
            buttonAnimator.SetBool("canSell", true);
        } else if(spawnScript.spawnedEggs.Count <= 0)
        {
            buttonAnimator.SetBool("canSell", false);
        }
    }

    public void Clicked()
    {
        buttonAnimator.SetTrigger("click");
    }
}