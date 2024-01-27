using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public GameObject PlayerSphere;
    public Vector3 OffSet;

    void Update()
    {
        transform.position = PlayerSphere.transform.position + OffSet;
    }
}
