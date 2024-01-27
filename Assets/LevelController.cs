using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    #region events
    public delegate void NextScene(WorldController controller);
    public static event NextScene OnNextScene;
    #endregion

    

    private int CurrentLevel = 0;

    public PlayerController playerController;

    public LevelStruct[] Levels;

    [System.Serializable]
    public struct LevelStruct
    {
        public Transform StartLevelPos;
        public WorldController WorldController;
    }
    void OnEnable()
    {
        LevelTrigger.onLevelTriggered += LevelEnabled;
    }
    void OnDisable()
    {
        LevelTrigger.onLevelTriggered -= LevelEnabled;
    }

    void LevelEnabled()
    {
        Levels[CurrentLevel].WorldController.isEnable = true;
    }

    public void Start()
    {
        CurrentLevel = 0;
        playerController = GameObject.FindObjectOfType<PlayerController>();
        OnNextScene?.Invoke(Levels[CurrentLevel].WorldController);
    }

    int GetCurrentLevel()
    {
        return CurrentLevel;
    }
    void SetCurrentLevel(int LevelNum)
    {
        CurrentLevel = LevelNum;
    }
    public void NextLevel()
    {
        Levels[CurrentLevel].WorldController.isEnable = false;
        CurrentLevel++;
        playerController.TeleportPlayer(Levels[CurrentLevel].StartLevelPos);
        OnNextScene?.Invoke(Levels[CurrentLevel].WorldController);
    }


}
