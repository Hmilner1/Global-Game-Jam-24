using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void TeleportPlayer(Transform Location)
    {
        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        transform.position = Location.position;
        
    }
}
