using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public static int score;
    public Text coinsScoreText;

    public static bool isGamePaused;

    public GameObject[] characterPrefabs;

    private void Awake()
    {
        int selctedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        Instantiate(characterPrefabs[selctedCharacter], transform.position, transform.rotation);
    }
    void Start()
    {
        Time.timeScale = 1;
        gameOver = isGameStarted = isGamePaused= false;
        numberOfCoins = score = 0;

    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + numberOfCoins);
            if (score > PlayerPrefs.GetInt("HighScore",0))
                PlayerPrefs.SetInt("HighScore", score);

            gameOverPanel.SetActive(true);
            Destroy(gameObject);
        }

        coinsScoreText.text = "coins:" + numberOfCoins+"\nscore:"+score;

        if (SwipeManager.tap  && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }


    }
}
