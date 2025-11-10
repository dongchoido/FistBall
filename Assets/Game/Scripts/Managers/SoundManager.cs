using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    [SerializeField] AudioClip music;

    public float MusicVolume { get; private set; }
    public float SFXVolume { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        PlayMusic(music);

    }
    void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat(ConstManager.soundMusicVolume, 1f);
        SFXVolume = PlayerPrefs.GetFloat(ConstManager.soundSFXVolume, 1f);

        ApplyVolumes();
        
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
        PlayerPrefs.SetFloat(ConstManager.soundMusicVolume, value);
        PlayerPrefs.Save();
        ApplyVolumes();
    }

    public void SetSFXVolume(float value)
    {
        SFXVolume = value;
        PlayerPrefs.SetFloat(ConstManager.soundSFXVolume, value);
        PlayerPrefs.Save();
        sfxSource.volume = value;
    }

    private void ApplyVolumes()
    {
        musicSource.volume = MusicVolume;
        sfxSource.volume = SFXVolume; 
    }
}
