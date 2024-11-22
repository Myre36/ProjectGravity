using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    public void LoadScene(int MainGameScene)
    {
        SceneManager.LoadScene(MainGameScene);
    }
}