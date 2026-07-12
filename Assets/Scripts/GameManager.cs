using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private bool isOver = false;

    void Awake() { Instance = this; }

    void Start()
    {
        gameOverPanel.SetActive(false);
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
        Application.Quit();
        }
    }
    public void AddScore(int points)
    {
        if (isOver) return;
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (isOver) return;
        isOver = true;

        int best = PlayerPrefs.GetInt("HighScore", 0);
        if (score > best)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Best: " + score;
        }

        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final: " + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
