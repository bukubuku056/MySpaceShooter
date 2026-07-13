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
    public GameObject startPanel;         // 开始菜单面板

    private int score = 0;
    private bool isOver = false;
    private bool started = false;         // 是否已开始

    void Awake() { Instance = this; }

    void Start()
    {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);       // 显示开始菜单
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    public bool IsPlaying() { return !isOver && started; }

    public int GetScore() { return score; }

    public void AddScore(int points)
    {
        if (isOver || !started) return;
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);  // 关闭开始菜单
        started = true;               // 游戏开始
    }

    public void QuitGame()
    {
        Application.Quit();
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
