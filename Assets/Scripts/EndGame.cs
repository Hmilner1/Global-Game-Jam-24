using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class EndGame : MonoBehaviour
{
    public PlayerStats PlayerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("Score", PlayerStats.Score);
            PlayerPrefs.SetInt("Lives", PlayerStats.Lives);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndScreen");
        }
    }
}
