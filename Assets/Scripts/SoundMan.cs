using UnityEngine;
using UnityEngine.UI;
public class SoundMan : MonoBehaviour
{

    public static SoundMan instance;

    [SerializeField] Slider soundFXSlider;

    [SerializeField] AudioSource soundFXAudioSource;

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

    void Start()
    {
  
        if (!PlayerPrefs.HasKey("soundFXVolume"))
        {
            PlayerPrefs.SetFloat("soundFXVolume", 1);
        }
        else
        {
            Load();
        }

        if (soundFXAudioSource == null)
        {
            soundFXAudioSource = GameObject.FindGameObjectWithTag("SoundFXAudioSource").GetComponent<AudioSource>();
        }
    }
    void FixedUpdate()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        soundFXAudioSource.volume = soundFXSlider.value;
        Save();
    }

    private void Load()
    {
        soundFXSlider.value = PlayerPrefs.GetFloat("soundFXVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("soundFXVolume", soundFXSlider.value);
    }
}
