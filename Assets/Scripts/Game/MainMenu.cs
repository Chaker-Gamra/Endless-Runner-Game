using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinsText;


    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        highScoreText.text = "High Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        coinsText.text = "Coins\n" + PlayerPrefs.GetInt("Coins", 0);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}
