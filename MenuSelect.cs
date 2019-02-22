using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{
    public GameObject bar;
    public Slider loadingBar;
    public void PlayGame()
    {
        bar.SetActive(true);
        StartCoroutine(LoadLev());
    }
    IEnumerator LoadLev()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("MainScene");

        while(!load.isDone)
        {
            float prog = Mathf.Clamp01(load.progress / 0.9f);
            loadingBar.value = prog;
            Debug.Log(load.progress);
            yield return null;
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
