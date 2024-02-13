using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Baseball"))
        {
            AddScore();
            UpdateScoreDisplay();
            Destroy(other.gameObject);

        }
    }
    void AddScore()
    {
        score++;
        UpdateScoreDisplay();
    }
    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}