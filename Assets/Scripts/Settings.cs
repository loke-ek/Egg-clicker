using UnityEngine;

public class Settings : MonoBehaviour
{

    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject settingsButton;

    private void Start()
    {
        settingsPanel.SetActive(false);
        settingsButton.SetActive(true);

    }
    public void Open()
    {
        settingsButton.SetActive(false);
        settingsPanel.SetActive(true);
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
    }

    public void Close()
    {
        settingsButton.SetActive(true);
        settingsPanel.SetActive(false);
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);

    }

}
