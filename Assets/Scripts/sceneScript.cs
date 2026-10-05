using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneScript : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK, 1);

    }

}
