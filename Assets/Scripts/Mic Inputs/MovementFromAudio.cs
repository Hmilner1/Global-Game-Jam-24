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
    private Vector3 minScale;
    [SerializeField] 
    private Vector3 loudScale;
    [SerializeField]
    private Vector3 quiteScale;
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

    private void Start()
    {
        running = false;
        non = true;
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
                StartCoroutine(MoveBackward());
                non = false;
                running = true;
            }
            else if (volume > loudnessThreshold)
            {
                StartCoroutine(MoveForward());
                non = false;
                running = true;
            }
            if (volume == 0)
            {
                non = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private IEnumerator MoveForward()
    {
        transform.localScale = Vector3.Lerp(minScale, loudScale, volume);
        yield return new WaitForSeconds(1);
        if (non)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        running = false;
        StopCoroutine(MoveForward());
    }

    private IEnumerator MoveBackward()
    {
        transform.localScale = Vector3.Lerp(minScale, quiteScale, volume);
        yield return new WaitForSeconds(1);
        if (non)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        running = false;
        StopCoroutine(MoveBackward());
    }
}
