using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("ouch!");
    }

    

    public void LoadGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");

        Debug.Log("help");
    }

    public void LoadMenuSettings()
    {
        SceneManager.LoadScene("MenuSettings");
    }

}