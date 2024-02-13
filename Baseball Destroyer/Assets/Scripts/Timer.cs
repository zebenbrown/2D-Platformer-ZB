using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI timerText;

   [SerializeField] private float time = 60f;

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
      UpdateTimerDisplay();
   }
}
