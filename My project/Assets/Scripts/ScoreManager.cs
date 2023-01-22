using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int Score { get; set; }

    [SerializeField] private TextMeshPro highScoreText;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro timeText;

    [SerializeField] private float initialTime;

    [SerializeField] private TextMeshProUGUI finalText;

    private bool restarting = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        highScoreText.text = "High Score\n" + PlayerPrefs.GetInt("highScore").ToString();

        Score = 0;

        finalText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (initialTime > 0f)
        {
            initialTime -= Time.deltaTime;
        }

        scoreText.text = Score.ToString();

        timeText.text = $"Time Left\n{initialTime.ToString("0")}s";

        if (initialTime <= 0f && !restarting)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
            FindObjectOfType<ItemSpawner>().CanSpawn = false;
            
            finalText.gameObject.SetActive(true);
            finalText.text = $"GAME OVER\nFINAL SCORE: {Score}\n\nGame Restarting...";

            if (PlayerPrefs.GetInt("highScore") < Score)
            {
                PlayerPrefs.SetInt("highScore", Score);
            }

            restarting = true;

            Invoke("RestartGame", 5f);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
