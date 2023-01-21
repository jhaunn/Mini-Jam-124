using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; set; }

    [SerializeField] private TextMeshPro scoreText;

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        scoreText.text = Score.ToString();   
    }
}
