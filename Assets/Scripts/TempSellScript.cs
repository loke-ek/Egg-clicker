using TMPro;
using UnityEngine;

public class TemporarySel : MonoBehaviour
{
    public static TemporarySel Instance;

    [SerializeField] EggSpawnScript eggSpawnScript;
    [SerializeField] TextMeshProUGUI moneyCounter_txt;

    [SerializeField] int Money;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyText();
    }

    public void SellEggs()
    {
        foreach (GameObject egg in eggSpawnScript.spawnedEggs)
        {
            if (egg != null)
            {
                // add the egg's value here
                // in the next step.
            }
        }

        eggSpawnScript.spawnedEggs.Clear();
    }

    private void UpdateMoneyText()
    {
        moneyCounter_txt.text = Money.ToString();
    }
}
