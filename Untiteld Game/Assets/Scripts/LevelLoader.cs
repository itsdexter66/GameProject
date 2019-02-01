using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoadManager : MonoBehaviour
{

    public GameObject LoadingScreen;
    public Slider slider;
    public Text ProgressText;

    /// <summary>
    /// Loads the level.
    /// </summary>
    /// <param name="sceneIndex">Scene index.</param>
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    /// <summary>
    /// Loads the asynchronously.
    /// </summary>
    /// <returns>The asynchronously.</returns>
    /// <param name="sceneIndex">Scene index.</param>
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            ProgressText.text = progress * 100f + "%";

            yield return null;
        }

    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

}
