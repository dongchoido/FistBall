using UnityEngine;
using System;

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
        if(Instance==null)
        {
            Instance = this;
        }

        MusicVolume = PlayerPrefs.GetFloat(ConstManager.soundMusicVolume, 1f);
        SFXVolume = PlayerPrefs.GetFloat(ConstManager.soundSFXVolume, 1f);

        ApplyVolumes();
        PlayMusic(music);
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, SFXVolume);
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
        PlayerPrefs.SetFloat(ConstManager.soundMusicVolume, value);
        ApplyVolumes();
    }

    public void SetSFXVolume(float value)
    {
        SFXVolume = value;
        PlayerPrefs.SetFloat(ConstManager.soundSFXVolume, value);
    }

    private void ApplyVolumes()
    {
        musicSource.volume = MusicVolume;
    }
}
