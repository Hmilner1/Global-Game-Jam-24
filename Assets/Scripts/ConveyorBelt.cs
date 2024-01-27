using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float Force = 50;
    void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            Vector3 forceDirection = -transform.TransformDirection(Vector3.forward);
            float forceMagnitude = Force; 
            otherRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            Debug.Log("Has Run");
        }
    }
}
