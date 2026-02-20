using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MainMenuBack()
    {

        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {

        SceneManager.LoadScene(1);
    }
}