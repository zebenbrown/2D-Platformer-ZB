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

    private void Update()
    {
        UpdateLives();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Player enters a hazard trigger
        if (other.gameObject.CompareTag("Hazard"))
        {
            if (!isHit)
            {
                isHit = true;
                
                //Respawn
                transform.position = respawn.transform.position;
                playerLives -= TakeDamage(1);
                UpdateLives();
                
                StartCoroutine(HitCooldown());
            }
        }
        //Player enters a checkpoint
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawn = other.transform;
        }
        //Player 
        else if (other.gameObject.CompareTag("Helmet"))
        {
            playerLives -= TakeDamage(1);
            UpdateLives();
            Destroy(other.gameObject);
        }
        if (playerLives < 1)
        {
            LoadScene();
        }
    }
    //Updates the lives text
    public void UpdateLives()
    {
        playerLivesText.text = "Lives: " + playerLives.ToString();
    }
    //Loads a different scene
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    //Creates a delay for when the player can take damage again
    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isHit = false;

    }

    public int TakeDamage(int damage)
    {
        return damage;
    }
}