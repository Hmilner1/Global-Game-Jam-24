using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelectMic : MonoBehaviour
{
    #region events
    public delegate void ChangeMic();
    public static event ChangeMic onChangeMic;
    #endregion

    public List<string> micList = new List<string>();
    private TMP_Dropdown micDropdown;
    private void Start()
    { 
        micDropdown= GetComponent<TMP_Dropdown>();

        micDropdown.onValueChanged.AddListener(SetCurrentMic);

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

    public void SetCurrentMic(int index)
    {
        MicMan.Instance.micName = micDropdown.options[index].text;
        onChangeMic?.Invoke();
    }
}
