using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor.Rendering;
using UnityEngine;

public class MovementFromAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    AudioDetection audioDetector;

    [SerializeField]
    float volume;
    [SerializeField]
    private float volumeSensitivity = 100;
    [SerializeField]
    private float threshold = 0.1f;
    [SerializeField]
    private float loudnessThreshold = 0.5f;
    [SerializeField]
    private float quiteThreshold = 0.5f;

    private bool running;
    private bool non;

    public bool forwards;
    public bool backwards;

    private WorldController localController;

    private void OnEnable()
    {
        LevelController.OnNextScene += SetWorldController;
        PlayerStats.onPlayerDied += ResetBools;
    }

    private void OnDisable()
    {
        LevelController.OnNextScene -= SetWorldController;
        PlayerStats.onPlayerDied -= ResetBools;
    }

    void ResetBools()
    {
        forwards = false;
        backwards = false;
    }

    private void Start()
    {
        running = false;
        non = true;
        forwards= false;
        backwards= false;
    }

    private void Update()
    {
        volume = audioDetector.GetAudioNoiseFromMic() * volumeSensitivity;

        if (volume < threshold)
        {
            volume = 0;
        }
        if (!running)
        {
            if (volume > quiteThreshold && volume < loudnessThreshold)
            {
                AudioManager.instance.PlayWalkingSound(transform.position);
                StartCoroutine(MoveBackward());
                non = false;
                running = true;
            }
            else if (volume > loudnessThreshold)
            {
                AudioManager.instance.PlayWalkingSound(transform.position);
                StartCoroutine(MoveForward());
                non = false;
                running = true;
            }
            if (volume == 0)
            {
                AudioManager.instance.StopWalkingSound();
                non = true;
                localController.ReturnToOriginal();
                ResetBools();
            }
        }
    }

    private IEnumerator MoveForward()
    { 
        
        backwards = false;
        forwards = true;
        yield return new WaitForSeconds(1);
        if (non)
        {
            
            //Here
        }
        running = false;
        StopCoroutine(MoveForward());
    }

    private IEnumerator MoveBackward()
    {
        
        forwards = false;
        backwards = true;
        yield return new WaitForSeconds(1);
        if (non)
        {
            //Here
        }
        running = false;
        StopCoroutine(MoveBackward());
    }

    private void SetWorldController(WorldController controller)
    {
        localController = controller;
    }
}
