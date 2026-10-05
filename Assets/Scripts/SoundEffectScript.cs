using UnityEngine;

public class SoundEffectScript : MonoBehaviour
{
    public static SoundEffectScript instance;

    [SerializeField] private AudioClip[] soundEffectList;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundEffectList[(int)sound], volume);
    }

    public enum SoundType
    {
        CLICK,
        CLICKCHICK,
        COLLECTMONEY,
        EGGCRACK, 
    }
}
