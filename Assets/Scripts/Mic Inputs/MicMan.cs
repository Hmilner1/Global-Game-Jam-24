using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicMan : MonoBehaviour
{
    public static MicMan Instance;
    public float currentVolumeSensitivity;
    public string micName;

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

        micName = Microphone.devices[0];
        currentVolumeSensitivity = 100;
    }

}
