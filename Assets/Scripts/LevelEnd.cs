using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public LevelController levelController;

    private bool fadeIn;
    private bool fadeOut;

    private CanvasGroup fadeCanvas;
    public float fadeSpeed;
    public float fadeDuration;
    public float endWaitDuration;

    void Start()
    {
        levelController = GameObject.FindObjectOfType<LevelController>();
        fadeCanvas = GameObject.Find("Fade Canvas").GetComponent<CanvasGroup>();
        fadeIn = false;
        fadeOut= false;
    }
    void OnTriggerEnter(Collider other)
    {

        StartCoroutine(EndWait());
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (fadeCanvas.alpha < 1)
            {
                fadeCanvas.alpha += fadeSpeed * Time.deltaTime;
            }
            else if (fadeCanvas.alpha >= 1)
            {
                StartCoroutine(FadeWait());
            }
        }

        if (fadeOut)
        {
            if (fadeCanvas.alpha >= 0)
            {
                fadeCanvas.alpha -= fadeSpeed * Time.deltaTime;

                if (fadeCanvas.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    private IEnumerator EndWait()
    {
        yield return new WaitForSeconds(endWaitDuration);
        fadeIn = true;
        levelController.NextLevel();
        StopCoroutine(EndWait());
    }

    private IEnumerator FadeWait()
    {
        fadeIn = false;
        yield return new WaitForSeconds(fadeDuration);
        fadeOut = true;
        StopCoroutine(FadeWait());
    }



}
