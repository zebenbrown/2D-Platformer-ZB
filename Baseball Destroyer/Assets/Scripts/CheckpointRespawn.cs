using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRespawn : MonoBehaviour
{
   [SerializeField] private Transform respawn;
   

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Checkpoint"))
      {
         GetComponent<Animator>().SetTrigger("OnPlayerEntry");
         respawn = other.transform;
      }
   }
}
