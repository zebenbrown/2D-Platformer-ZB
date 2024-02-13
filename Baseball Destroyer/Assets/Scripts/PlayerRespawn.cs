using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI playerLivesText;
    [SerializeField] private Transform respawn;
    private int playerLives = 3;
    [SerializeField] private string sceneName;
    private bool isHit = false;
    private int Overlap = 0;

    private void Update()
    {
        UpdateLives();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            if (!isHit)
            {
                isHit = true;
                
                //Respawn
                transform.position = respawn.transform.position;
                playerLives--;
                UpdateLives();
                
                StartCoroutine(HitCooldown());
            }
            
            if (playerLives < 1)
            {
               LoadScene();
            }
        }

        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawn = other.transform;
        }
    }

    void UpdateLives()
    {
        playerLivesText.text = "Lives: " + playerLives.ToString();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isHit = false;

    }
}
