using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int Score { get; set; }

    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro timeText;

    [SerializeField] private float initialTime;

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
        Score = 0;
    }

    private void Update()
    {
        initialTime -= Time.deltaTime;

        scoreText.text = Score.ToString();
        timeText.text = $"Time Left\n{initialTime.ToString("0.00")}s";
    }
}
