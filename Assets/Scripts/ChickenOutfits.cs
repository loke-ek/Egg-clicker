using UnityEngine;
using UnityEngine.UI;

public class ChickenOutfits : MonoBehaviour
{
    [SerializeField] Image chickenImage;
    [SerializeField] TemporarySel moneyScript;

    [SerializeField] Sprite originalSprite;
    [SerializeField] Sprite outfit1Sprite;
    [SerializeField] Sprite outfit2Sprite;
    [SerializeField] Sprite outfit3Sprite;

    [SerializeField] int outfit1Cost = 500;
    [SerializeField] int outfit2Cost = 1500;
    [SerializeField] int outfit3Cost = 1500;

    private bool outfit1Unlocked = false;
    private bool outfit2Unlocked = false;
    private bool outfit3Unlocked = false;

    public void BuyOutfit1()
    {
        if (outfit1Unlocked)
            return;

        if (moneyScript.Money < outfit1Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit1Cost);
        outfit1Unlocked = true;
        Debug.Log("Outfit 1 unlocked!");
    }

    public void BuyOutfit2()
    {
        if (outfit2Unlocked)
            return;

        if (moneyScript.Money < outfit2Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit2Cost);
        outfit2Unlocked = true;
        Debug.Log("Outfit 2 unlocked!");
    }

    public void BuyOutfit3()
    {
        if (outfit3Unlocked)
            return;

        if (moneyScript.Money < outfit3Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit3Cost);
        outfit3Unlocked = true;
        Debug.Log("Outfit 3 unlocked!");
    }

    public void WearOutfit1()
    {
        if (!outfit1Unlocked)
        {
            Debug.Log("Buy outfit 1 first!");
            return;
        }

        chickenImage.sprite = outfit1Sprite;
    }

    public void WearOutfit2()
    {
        if (!outfit2Unlocked)
        {
            Debug.Log("Buy outfit 2 first!");
            return;
        }

        chickenImage.sprite = outfit2Sprite;
    }

    public void WearOutfit3()
    {
        if (!outfit3Unlocked)
        {
            Debug.Log("Buy outfit 3 first!");
            return;
        }

        chickenImage.sprite = outfit3Sprite;
    }

    public void WearOriginal()
    {
        chickenImage.sprite = originalSprite;
    }
}
