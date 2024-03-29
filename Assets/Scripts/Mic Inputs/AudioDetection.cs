using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UISelectMic;

public class AudioDetection : MonoBehaviour
{
    [SerializeField]
    private int audioSample = 64;
    private AudioClip micAudioClip;
    private string selectedMic;

    private void OnEnable()
    {
        UISelectMic.onChangeMic += ChangeMic;
    }

    private void OnDisable()
    {
        UISelectMic.onChangeMic -= ChangeMic;
    }

    private void Start()
    {
        selectedMic = MicMan.Instance.micName;
        MicToAudio();
    }

    private void ChangeMic()
    {
        selectedMic = MicMan.Instance.micName;
    }

    public void MicToAudio()
    {
        micAudioClip = Microphone.Start(selectedMic, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetAudioNoiseFromMic()
    {
        return GetAudioNoise(Microphone.GetPosition(selectedMic), micAudioClip);
    }

    public float GetAudioNoise(int clipTime, AudioClip clip)
    {
        int startPos = clipTime - audioSample;

        if (startPos < 0)
        {
            return 0;
        }

        float[] waveData = new float[audioSample];
        clip.GetData(waveData, startPos);

        float volume = 0;

        for (int i = 0; i < audioSample; i++)
        {
            volume += Mathf.Abs(waveData[i]);
        }

        return volume / audioSample;
    }
}
