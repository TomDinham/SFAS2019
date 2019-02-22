using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Ispause = false;
    public GameObject PasueMenu;
    public GameObject GameUI;
	// Update is called once per frame
	void Update () 
    {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Ispause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume()
    {
        PasueMenu.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
        Ispause = false;
    }
   void Pause()
    {

        PasueMenu.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0;
        Ispause = true;
    }
    public void GotToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   public  void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
       
    }
}
