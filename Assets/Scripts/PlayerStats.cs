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
    private bool Grounded;

    void OnEnable()
    {
        Pickups.onScoreTrigger += AddScore;
    }

    void OnDisable()
    {
        Pickups.onScoreTrigger -= AddScore;
    }
    private void Start()
    {
        Grounded = true;
    }

    void Update()
    {
        if (Grounded)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit, raycastDistance))
            {
                PlayerDied();
            }
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
        }
    }

    void PlayerDied()
    {
        Lives--;
        Grounded= false;
        if (Lives <= 0)
        {
            SceneMan.Instance.LoadScene("EndScreen ded");
        }
        StartCoroutine(RespawnWait());
    }

    private IEnumerator RespawnWait()
    {
        yield return new WaitForSeconds(1);
        onPlayerDied?.Invoke();
        AudioManager.instance.PlaySoundEffect(PLayerDiedAudioClip, transform.position);
        Grounded = true;
        StopCoroutine(RespawnWait());
    }

    void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        ScoreText.text = Score.ToString();
    }
}
