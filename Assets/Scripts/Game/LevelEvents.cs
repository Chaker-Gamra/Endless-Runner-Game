using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    public GameObject gamePausedPanel;
    public Button pauseButton; 

    private void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (PlayerManager.gameOver)
            pauseButton.interactable = false;

        if (PlayerManager.gameOver)
            return;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PlayerManager.isGamePaused)
            {
                ResumeGame();
                gamePausedPanel.SetActive(false);
            }
            else
            {
                PauseGame();
                gamePausedPanel.SetActive(true);
            }

        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame()
    {
        if (!PlayerManager.isGamePaused && !PlayerManager.gameOver)
        {
            Time.timeScale = 0;
            PlayerManager.isGamePaused = true;
        }
    }
    public void ResumeGame()
    {
        if (PlayerManager.isGamePaused)
        {
            Time.timeScale = 1;
            PlayerManager.isGamePaused = false;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
