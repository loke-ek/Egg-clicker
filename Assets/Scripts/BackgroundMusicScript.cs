using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundMusicScript : MonoBehaviour
{
    private static BackgroundMusicScript instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip BackgroundMusic;


    [SerializeField] Slider musicVolSlider;

    private void Awake()
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
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }

    }

    void FixedUpdate()
    {
        ChangeVolume();
    }

    private void Update()
    {

        if (!audioSource.isPlaying) audioSource.Play();
    }

    public void ChangeVolume()
    {
        audioSource.volume = musicVolSlider.value;
        Save();
    }

    private void Load()
    {
        musicVolSlider.value = PlayerPrefs.GetFloat("musicVolSlider");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolSlider", musicVolSlider.value);
    }

}
