using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHearts : MonoBehaviour
{
    private GameObject heartHolder;

    private void OnEnable()
    {
        PlayerStats.onPlayerDied += RemoveHeart;
    }

    private void OnDisable()
    {
        PlayerStats.onPlayerDied -= RemoveHeart;
    }

    private void Start()
    {
        heartHolder = GameObject.Find("Heart Holder");
    }

    private void RemoveHeart()
    {
        List<GameObject> hearts = new List<GameObject>();
        foreach (Transform heart in heartHolder.gameObject.transform)
        {
            if (heart == null)
            {
                return;
            }
            hearts.Add(heart.gameObject);
        }
        if (hearts.Count > 0)
        {
            Destroy(hearts[hearts.Count - 1]);
        }
    }
}
