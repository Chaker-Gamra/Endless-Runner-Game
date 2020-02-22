using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (SwipeManager.tap  && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }

    }
}
