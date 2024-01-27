using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotae : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    [SerializeField]
    private GameObject SceneMan;

    private void Start()
    {
        Instantiate(SceneMan);
    }

    void Update()
    {  
        Material skyboxMaterial = RenderSettings.skybox;
        float newRotation = Time.time * rotationSpeed % 360f;

        skyboxMaterial.SetFloat("_Rotation", newRotation);

        RenderSettings.skybox = skyboxMaterial;
    }
}
