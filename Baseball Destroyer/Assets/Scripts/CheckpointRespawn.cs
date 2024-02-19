using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRespawn : MonoBehaviour
{
   [SerializeField] private Transform respawn;
   //[SerializeField] private Animator animator;
   
   

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Checkpoint"))
      {
         respawn = other.transform;
      }
   }
}
