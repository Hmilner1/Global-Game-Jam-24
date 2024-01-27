using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int CurrentLevel = 0;

    public PlayerController playerController;

    public LevelStruct[] Levels;

    [System.Serializable]
    public struct LevelStruct
    {
        public Transform StartLevelPos;
        public WorldController WorldController;
    }

    public void Start()
    {
        CurrentLevel = 0;
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Levels[CurrentLevel].WorldController.isEnable = true;

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
        Levels[CurrentLevel].WorldController.isEnable = true;
    }


}
