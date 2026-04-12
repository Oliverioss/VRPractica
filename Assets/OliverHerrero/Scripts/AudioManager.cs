using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip[] pointSound, bombSound, buttonSound, loseSound, victorySound;
    public AudioSource musicSource, sfxSource;

    public AudioClip EasyTheme, DifficultTheme, ArrowTheme, MenuTheme;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip)
        {
            return;
        }
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu" || scene.name == "Victoria" || scene.name == "Derrota")
        {
            PlayMusic(MenuTheme);
        }
        else if (scene.name == "Facil")
        {
            PlayMusic(EasyTheme);
        }
        else if (scene.name == "Dificil")
        {
            PlayMusic(DifficultTheme);
        }
        else if(scene.name == "Flechas")
        {
            PlayMusic(ArrowTheme);
        }
    }
    public void PlayPointSound()
    {
        sfxSource.PlayOneShot(pointSound[0]);
    }
    public void PlayBombSound()
    {
        sfxSource.PlayOneShot(bombSound[0]);
    }
    public void PlayButton()
    {
        sfxSource.PlayOneShot(buttonSound[0]);
    }
    public void PlayLoseSound()
    {
        sfxSource.PlayOneShot(loseSound[0]);
    }
    public void PlayVictorySound()
    {
        sfxSource.PlayOneShot(victorySound[0]);
    }
}
