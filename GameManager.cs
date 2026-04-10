using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;                         

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameSpeed = 5f;
    public float speedIncreaseRate = 0.1f;

    public TMP_Text scoreText;        
    public TMP_Text highScoreText;
    public GameObject gameOverPanel;

    private float score = 0f;
    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }
    private AudioSource musicSource;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
        //display loaded high score
    }
    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime * gameSpeed;
        //increases score based on time and game speed
        gameSpeed += speedIncreaseRate * Time.deltaTime;
        //increases game speed over time
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
        //updates score
    }

    public void GameOver()
    {
        isGameOver = true;
        musicSource.Stop(); // stops music on game over
        // save high score
        int currentScore = Mathf.FloorToInt(score);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }//checks if current score is higher than high score and saves it if it is

        // update display
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0);

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //unfreeze and reload scene
    }
}