using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelectMic : MonoBehaviour
{
    public List<string> micList = new List<string>();
    private TMP_Dropdown micDropdown;
    private void Start()
    { 
        micDropdown= GetComponent<TMP_Dropdown>();

        foreach (string microphone in Microphone.devices) 
        {
            micList.Add(microphone);
        }

        DisplayMics();
    }

    public void DisplayMics()
    {
        micDropdown.AddOptions(micList);
    }
}
