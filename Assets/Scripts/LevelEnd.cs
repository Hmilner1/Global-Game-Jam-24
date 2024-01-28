using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public LevelController levelController;
    public ParticleSystem particleSystem;
    void Start()
    {
        levelController = GameObject.FindObjectOfType<LevelController>();
    }
    void OnTriggerEnter(Collider other)
    {
        particleSystem.Play();
        levelController.NextLevel();
    }

}
