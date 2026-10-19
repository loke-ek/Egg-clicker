using UnityEngine;
using UnityEngine.UI;

public class ChickenOutfits : MonoBehaviour
{
    [SerializeField] Image[] outfitImages;
    [SerializeField] ChickenOutfitSO[] outfits;

    [SerializeField] TemporarySel moneyScript;

    private bool[] unlocked;

    private void Start()
    {
        unlocked = new bool[outfits.Length];

        for (int i = 0; i < outfitImages.Length; i++)
        {
            outfitImages[i].sprite = outfits[i].outfitImage;
            outfitImages[i].gameObject.SetActive(false);

            // Makes sure the outfit doesn't block the chicken button
            outfitImages[i].raycastTarget = false;
        }
    }

    public void BuyOrToggleOutfit(int index)
    {
        if (index < 0 || index >= outfits.Length)
            return;

        if (!unlocked[index])
        {
            if (moneyScript.Money < outfits[index].cost)
            {
                Debug.Log("Not enough money!");
                return;
            }

            moneyScript.AddMoney(-outfits[index].cost);

            unlocked[index] = true;

            outfitImages[index].gameObject.SetActive(true);

            Debug.Log("Outfit " + (index + 1) + " unlocked!");
        }
        else
        {
            ToggleOutfit(index);
        }
    }

    private void ToggleOutfit(int index)
    {
        bool currentlyVisible = outfitImages[index].gameObject.activeSelf;

        outfitImages[index].gameObject.SetActive(!currentlyVisible);
    }
}