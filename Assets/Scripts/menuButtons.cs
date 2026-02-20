using System.Collections;
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
        Destroy(FindFirstObjectByType<ScoreKeeper>());
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitForload("EndGame"));
    }

    IEnumerator WaitForload(string scene)
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }

    public void NewGame()
    {
        Destroy(FindFirstObjectByType<ScoreKeeper>());
        SceneManager.LoadScene(1);
    }
}