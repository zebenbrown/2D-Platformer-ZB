using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreDisplay();
        
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Baseball"))
        {
            AddScore();
            Destroy(other.gameObject);
            
        }
    }

    void AddScore()
    {
        score++;
        Debug.Log("Score + 1");
        UpdateScoreDisplay();
    }
}
