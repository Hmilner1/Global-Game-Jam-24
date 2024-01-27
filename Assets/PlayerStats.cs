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

    [SerializeField]
    private float Timer = 0;
    [SerializeField]
    private int Score = 0;
    [SerializeField]
    private int Lives = 3;

    public TextMeshProUGUI ScoreText;

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
    }

    void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        ScoreText.text = Score.ToString();

    }
}
