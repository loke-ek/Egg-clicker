using UnityEngine;
using UnityEngine.UI;

public class ChickenOutfits : MonoBehaviour
{
    [SerializeField] Image outfit1Image;
    [SerializeField] Image outfit2Image;
    [SerializeField] Image outfit3Image;
    [SerializeField] Image outfit4Image;
    [SerializeField] Image outfit5Image;

    [SerializeField] TemporarySel moneyScript;

    [SerializeField] Sprite outfit1Sprite;
    [SerializeField] Sprite outfit2Sprite;
    [SerializeField] Sprite outfit3Sprite;
    [SerializeField] Sprite outfit4Sprite;
    [SerializeField] Sprite outfit5Sprite;

    [SerializeField] int outfit1Cost = 500;
    [SerializeField] int outfit2Cost = 1500;
    [SerializeField] int outfit3Cost = 1500;
    [SerializeField] int outfit4Cost = 1500;
    [SerializeField] int outfit5Cost = 1500;

    private bool outfit1Unlocked = false;
    private bool outfit2Unlocked = false;
    private bool outfit3Unlocked = false;
    private bool outfit4Unlocked = false;
    private bool outfit5Unlocked = false;

    private void Start()
    {
        outfit1Image.gameObject.SetActive(false);
        outfit2Image.gameObject.SetActive(false);
        outfit3Image.gameObject.SetActive(false);
        outfit4Image.gameObject.SetActive(false);
        outfit5Image.gameObject.SetActive(false);

        outfit1Image.sprite = outfit1Sprite;
        outfit2Image.sprite = outfit2Sprite;
        outfit3Image.sprite = outfit3Sprite;
        outfit4Image.sprite = outfit3Sprite;
        outfit5Image.sprite = outfit3Sprite;
    }

    public void BuyOutfit1()
    {
        if (outfit1Unlocked)
        {
            ToggleOutfit1();
            return;
        }

        if (moneyScript.Money < outfit1Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit1Cost);

        outfit1Unlocked = true;

        outfit1Image.gameObject.SetActive(true);

        Debug.Log("Outfit 1 unlocked!");
    }

    public void BuyOutfit2()
    {
        if (outfit2Unlocked)
        {
            ToggleOutfit2();
            return;
        }

        if (moneyScript.Money < outfit2Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit2Cost);

        outfit2Unlocked = true;

        outfit2Image.gameObject.SetActive(true);

        Debug.Log("Outfit 2 unlocked!");
    }

    public void BuyOutfit3()
    {
        if (outfit3Unlocked)
        {
            ToggleOutfit3();
            return;
        }

        if (moneyScript.Money < outfit3Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit3Cost);

        outfit3Unlocked = true;

        outfit3Image.gameObject.SetActive(true);

        Debug.Log("Outfit 3 unlocked!");
    }

    public void BuyOutfit4()
    {
        if (outfit4Unlocked)
        {
            ToggleOutfit4();
            return;
        }

        if (moneyScript.Money < outfit4Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit4Cost);

        outfit4Unlocked = true;

        outfit4Image.gameObject.SetActive(true);

        Debug.Log("Outfit 4 unlocked!");
    }

    public void BuyOutfit5()
    {
        if (outfit5Unlocked)
        {
            ToggleOutfit5();
            return;
        }

        if (moneyScript.Money < outfit5Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        moneyScript.AddMoney(-outfit5Cost);

        outfit5Unlocked = true;

        outfit5Image.gameObject.SetActive(true);

        Debug.Log("Outfit 5 unlocked!");
    }

    public void ToggleOutfit1()
    {
        if (!outfit1Unlocked)
        {
            Debug.Log("Buy outfit 1 first!");
            return;
        }

        outfit1Image.gameObject.SetActive(!outfit1Image.gameObject.activeSelf);
    }

    public void ToggleOutfit2()
    {
        if (!outfit2Unlocked)
        {
            Debug.Log("Buy outfit 2 first!");
            return;
        }

        outfit2Image.gameObject.SetActive(!outfit2Image.gameObject.activeSelf);
    }

    public void ToggleOutfit3()
    {
        if (!outfit3Unlocked)
        {
            Debug.Log("Buy outfit 3 first!");
            return;
        }

        outfit3Image.gameObject.SetActive(!outfit3Image.gameObject.activeSelf);
    }

    public void ToggleOutfit4()
    {
        if (!outfit4Unlocked)
        {
            Debug.Log("Buy outfit 3 first!");
            return;
        }

        outfit4Image.gameObject.SetActive(!outfit4Image.gameObject.activeSelf);
    }

    public void ToggleOutfit5()
    {
        if (!outfit5Unlocked)
        {
            Debug.Log("Buy outfit 5 first!");
            return;
        }

        outfit5Image.gameObject.SetActive(!outfit5Image.gameObject.activeSelf);
    }
}