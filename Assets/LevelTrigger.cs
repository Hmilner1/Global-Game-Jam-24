using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    #region events
    public delegate void TriggerLevel();
    public static event TriggerLevel onLevelTriggered;
    #endregion

    void OnTriggerEnter()
    {
        onLevelTriggered?.Invoke();
    }
}
