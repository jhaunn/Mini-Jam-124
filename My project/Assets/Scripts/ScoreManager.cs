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

    [SerializeField] private GameObject[] upgrades;
    private int currentUpgrade = 0;

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

        foreach (GameObject item in upgrades)
        {
            item.SetActive(false);
        }
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

        if (Score >= 25f && currentUpgrade == 0)
        {
            upgrades[0].SetActive(true);
            currentUpgrade++;
        }
        if (Score >= 50f && currentUpgrade == 1)
        {
            upgrades[1].SetActive(true);
            currentUpgrade++;
        }
        if (Score >= 75f && currentUpgrade == 2)
        {
            FindObjectOfType<PlayerInventory>().UpgradeInventory();
            currentUpgrade++;
        }
        if (Score >= 150f && currentUpgrade == 3)
        {
            FindObjectOfType<PlayerInventory>().UpgradeInventory();
            currentUpgrade++;
        }
        if (Score >= 250f && currentUpgrade == 4)
        {
            FindObjectOfType<PlayerInventory>().UpgradeInventory();
            currentUpgrade++;
        }

    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
