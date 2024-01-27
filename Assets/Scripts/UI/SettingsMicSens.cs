using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMicSens : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    AudioDetection audioDetector;

    public Image fillImage;
    public Slider sensSlider;

    [SerializeField]
    float volume;
    [SerializeField]
    private float currentVolumeSensitivity = 100;
    [SerializeField]
    private float minvVlumeSensitivity = 0;
    [SerializeField]
    private float maxVolumeSensitivity = 100;
    [SerializeField]
    private float threshold = 0.1f;
    [SerializeField]
    private float loudnessThreshold = 0.5f;
    [SerializeField]
    private float quiteThreshold = 0.5f;

    private void Start()
    {
        if (sensSlider == null)
        {
            return;
        }

        sensSlider.value = 0.5f;
        SetVolumeSensitivity(sensSlider.value);
    }
    private void Update()
    {
        volume = audioDetector.GetAudioNoiseFromMic() * currentVolumeSensitivity;

        if (volume < threshold)
        {
            volume = 0.1f;
        }
        
        fillImage.fillAmount = volume/10;
    }

    public void SetVolumeSensitivity(float amount)
    {
        currentVolumeSensitivity = Mathf.Lerp(minvVlumeSensitivity, maxVolumeSensitivity, amount);
        MicMan.Instance.currentVolumeSensitivity = currentVolumeSensitivity;
    }
}
