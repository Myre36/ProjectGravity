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
        SceneManager.LoadScene("MainGameScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadMenuSettings()
    {
        SceneManager.LoadScene("MenuSettings");
    }

}