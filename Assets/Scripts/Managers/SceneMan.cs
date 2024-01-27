using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneMan : MonoBehaviour
{
    public static SceneMan Instance;

    [SerializeField]
    private GameObject loadCanvas;

    private float target;

    void Awake()
    {
        Application.targetFrameRate = 140;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        target = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loadCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        }
        while (scene.progress < 0.9f);

        await Task.Delay(100);

        scene.allowSceneActivation = true;
        await Task.Delay(10);
        loadCanvas.SetActive(false);
    }

    public async void LoadSceneAdditive(string sceneName)
    {
        target = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;

        loadCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        }
        while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        await Task.Delay(10);
        loadCanvas.SetActive(false);
    }

    public async void UnLoadScene(string sceneName)
    {
        target = 0;

        var scene = SceneManager.UnloadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loadCanvas.SetActive(true);

        do
        {
            await Task.Delay(10);
            target = scene.progress;
        }
        while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        await Task.Delay(10);
        loadCanvas.SetActive(false);
    }


    public void OnClickExit()
    { 
        Application.Quit();
    }
}
