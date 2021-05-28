using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject PauseMenu;
    public void PauseButtonPressed()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void MenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void ReplyButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void ResumeButtonPressed()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
}
