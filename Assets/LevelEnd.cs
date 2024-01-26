using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public LevelController levelController;
    void Start()
    {
        levelController = GameObject.FindObjectOfType<LevelController>();
    }
    void OnTriggerEnter(Collider other)
    {
        levelController.NextLevel();
    }

}
