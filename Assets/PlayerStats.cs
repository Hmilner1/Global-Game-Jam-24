using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    #region events
    public delegate void PlayerHasDied();
    public static event PlayerHasDied onPlayerDied;
    #endregion

    public int Score = 0;

    public int Lives = 3;

    public TextMeshProUGUI ScoreText;

    public AudioClip PLayerDiedAudioClip;

    public float raycastDistance = 100f;

    void OnEnable()
    {
        Pickups.onScoreTrigger += AddScore;
    }

    void OnDisable()
    {
        Pickups.onScoreTrigger -= AddScore;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, raycastDistance))
        {
            PlayerDied();
        }
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }

    void PlayerDied()
    {
        Lives--;
        //TODO: Add Logic For Death
        onPlayerDied?.Invoke();
        AudioManager.instance.PlaySoundEffect(PLayerDiedAudioClip, transform.position);
    }

    void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        ScoreText.text = Score.ToString();
    }
}
