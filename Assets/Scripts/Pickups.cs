using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    #region events
    public delegate void TriggerAddScore(int ScoreToAdd );
    public static event TriggerAddScore onScoreTrigger;
    #endregion

    public AudioClip PickupAudioClip;

    [SerializeField]
    private int Score = 1;

    public float rotationDuration = 2f;
    public float bobbingHeight = 0.5f;
    public float bobbingDuration = 1f;

    public ParticleSystem particleSystem;

    void Start()
    {
        StartTurnAndBob();
    }
    void StartTurnAndBob()
    {
        LeanTween.rotateAround(gameObject, Vector3.up, 360f, rotationDuration).setLoopClamp();

        LeanTween.moveLocalY(gameObject, bobbingHeight, bobbingDuration).setLoopPingPong();
    }

    void OnTriggerEnter()
   {
       onScoreTrigger?.Invoke(Score);
       AudioManager.instance.PlaySoundEffect(PickupAudioClip, transform.position);
       particleSystem.Play();
       GetComponent<Collider>().enabled = false;
       GetComponent<Renderer>().enabled = false;

    }
}
