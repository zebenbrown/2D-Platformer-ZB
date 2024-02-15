using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI timerText;

   [SerializeField] private float time = 60f;

   [SerializeReference] private string sceneName;

   private int roundedTime;
   private void Start()
   {
      GameTimer();
      
   }

   private void Update()
   {
      GameTimer();
   }

   void UpdateTimerDisplay()
   {
      timerText.text = "Time: " + roundedTime.ToString();
   }

   void GameTimer()
   {
      roundedTime = Mathf.RoundToInt(time -= Time.deltaTime);
      if (roundedTime < 1)
      {
        LoadScene();
      }
      UpdateTimerDisplay();
   }

   private void LoadScene()
   {
      SceneManager.LoadScene(sceneName);
   }
}
