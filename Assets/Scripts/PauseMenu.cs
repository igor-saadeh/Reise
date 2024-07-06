using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;

    private void Update()
    {
        if (isGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        //gameObject.SetActive(true);
    }

    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        //gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
