using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private SceneName sceneName = new SceneName();

    public static SceneManage instance;

    public enum Scene
    {
        TITLE,
        GAME,
        ENDING
    }

    public Scene scene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        NextSneceKeyTitle();
        NextSneceKeyGame();
        NextSneceKeyEnding();
        Debug.Log("今のシーン:" + scene);
    }

    //R:game
    //T:title
    //Y:ending
    public void NextSneceKeyTitle()
    {
        if (!Input.GetKeyDown(KeyCode.G)) return;
        scene = Scene.GAME;
        SceneManager.LoadScene(sceneName.gameSceneName);

    }

    //仮置き　これを呼び出すとシーンが切り替わる。
    public void NextSneceKeyGame()
    {
        if (!Input.GetKeyDown(KeyCode.T)) return;
        scene = Scene.TITLE;
        SceneManager.LoadScene(sceneName.titleSceneName);
    }

    public void NextSneceKeyEnding()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        scene = Scene.ENDING;
        SceneManager.LoadScene(sceneName.endingSceneName);
    }

}
