using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
