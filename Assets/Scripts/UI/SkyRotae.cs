using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotae : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    [SerializeField]
    private GameObject SceneMan;
    [SerializeField]
    private GameObject MicMan;

    private void Start()
    {
        Instantiate(SceneMan);
        Instantiate(MicMan);
    }

    void Update()
    {  
        Material skyboxMaterial = RenderSettings.skybox;
        float newRotation = Time.time * rotationSpeed % 360f;

        skyboxMaterial.SetFloat("_Rotation", newRotation);

        RenderSettings.skybox = skyboxMaterial;
    }
}
