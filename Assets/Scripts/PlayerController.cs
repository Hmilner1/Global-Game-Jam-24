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
            playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.constraints = RigidbodyConstraints.None;
        }
        transform.position = Location.position;
        
    }
}
