using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure to add this at the top of your script



public class FinalScreenStat : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    void Start()
    {
        int temp = PlayerPrefs.GetInt("Score", 0);
        ScoreText.text = temp.ToString();
        int Lives = PlayerPrefs.GetInt("Lives", 0);
        LivesText.text = Lives.ToString();

    }

}
