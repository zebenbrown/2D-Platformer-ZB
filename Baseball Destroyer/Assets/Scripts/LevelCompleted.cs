using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    public SwitchScene switchScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        switchScene.LoadScene();
    }
}
