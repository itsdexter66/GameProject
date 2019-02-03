using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoadManager : MonoBehaviour
{

    //This script needs to be put on an Empty GameObject.

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

        //Unity progress goes from 0.0 to 0.9(for loading) and from 0.9 to 1.0(for actavating the assets) 
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //This makes it so that the loading from 0.0 to 0.9 are shwon on a bar as 0.0 to 1.0

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
