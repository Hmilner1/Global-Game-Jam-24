using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerSphere;
    public Vector3 OffSet;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position = PlayerSphere.transform.position + OffSet;

    }
}
