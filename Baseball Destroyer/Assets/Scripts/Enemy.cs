using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public Projectile projectile;
   [SerializeField] private float moveSpeed = 5f;

   [SerializeField] private Transform[] movePoints;
   private Rigidbody2D rb;

   private int pointIndex = 0;

   private Transform currentPoint;
   private void Start()
   {
      currentPoint = movePoints[pointIndex];
   }
   //Enemy Movement
    private void FixedUpdate()
    {
       transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, moveSpeed);
       if (Vector2.Distance(transform.position, currentPoint.position) < 0.01f)
       {
          pointIndex++;
          pointIndex %= movePoints.Length;
          currentPoint = movePoints[pointIndex];
       if (currentPoint == movePoints[0])
       {
          //If player in box cast flip enemy
          if (projectile.playerDetected)
          {
             GetComponent<SpriteRenderer>().flipX = false;
          }
          else
          {
             GetComponent<SpriteRenderer>().flipX = true;
          }
       }
       else
       {
          GetComponent<SpriteRenderer>().flipX = false;
       }
       }
    }
   
   
}


