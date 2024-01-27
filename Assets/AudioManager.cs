using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource backGroundSound;
    private AudioSource sfxSource;


    [SerializeField]
    private AudioClip backgroundAudioClip;

    [SerializeField]
    private float backgroundVolume;

    [SerializeField]
    private float soundSfxVolume;

    public AudioClip walkingSound;

    private AudioSource walkingSource;



    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        backGroundSound = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        walkingSource = gameObject.AddComponent<AudioSource>();
        walkingSource.volume = 3f;
        AdjustBackgroundSoundVolume(backgroundVolume);
        PlaybackgroundSound(backgroundAudioClip);
        AdjustVolume(soundSfxVolume);
    }
    void PlaybackgroundSound(AudioClip backgroundSound)
    {
        backGroundSound.clip = backgroundSound;
        backGroundSound.loop = true;
        backGroundSound.Play();
    }
    public void StopBackgroundMusic()
    {
        backGroundSound.Stop();
    }
    public void PlaySoundEffect(AudioClip soundEffect, Vector3 position)
    {
        sfxSource.transform.position = position;
        sfxSource.clip = soundEffect;
        sfxSource.spatialBlend = 1.0f; 
        sfxSource.Play();
    }
    public void AdjustBackgroundSoundVolume(float volume)
    {
        backGroundSound.volume = volume;
    }
    public void AdjustVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    public void PlayWalkingSound(Vector3 position)
    {
        walkingSource.transform.position = position;
        walkingSource.clip = walkingSound;
        walkingSource.spatialBlend = 1.0f;
        walkingSource.loop = true;
        walkingSource.Play();
    }

    public void StopWalkingSound()
    {
        walkingSource.Stop();
    }

}
