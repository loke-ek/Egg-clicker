using UnityEngine;

public class OutfitPanelButton : MonoBehaviour
{
    [SerializeField] private GameObject outfitPanel;


    public void ToggleOutfitPanel()
    {
        if (outfitPanel != null)
        {
            bool isActive = outfitPanel.activeSelf;
            outfitPanel.SetActive(!isActive);
        }
    }


    public void CloseOutfitPanel()
    {
        if (outfitPanel != null)
        {
            outfitPanel.SetActive(false);
        }
    }
}
