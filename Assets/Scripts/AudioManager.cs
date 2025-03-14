using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public AudioSource musicSource, sfxSource;
    public AudioClip backgroundSound, shootSound, loseSound; 
    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic () {
        musicSource.clip = backgroundSound;
        musicSource.loop = true;
        musicSource.Play();
        musicSource.volume = 0.3f;
    }

    private void PlaySFX (AudioClip clip) {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayShootSound () {
        PlaySFX(shootSound);
    }

    public void PlayLoseSound () {
        PlaySFX(loseSound);
    }
}
