using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoll : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }
}
