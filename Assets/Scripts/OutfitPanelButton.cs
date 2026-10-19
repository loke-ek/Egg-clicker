using UnityEngine;

public class OutfitPanelButton : MonoBehaviour
{
    [SerializeField] public GameObject outfitPanel;

    public void OnButtonClick()
    {
        // Call the method in the OutfitPanel script to open the panel
        outfitPanel.GetComponent<OutfitPanel>().OpenPanel();
    }
}
