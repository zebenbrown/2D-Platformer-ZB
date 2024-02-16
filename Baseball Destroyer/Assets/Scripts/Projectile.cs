using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject helmetPrefab;
    
    private bool canFire = true;
    //[SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask playerLayerMask;
    private RaycastHit2D hit2D;
    [SerializeField] private LineRenderer render;
    [SerializeField] private float maxDistance = 10f;
    
    private void FixedUpdate()
    {
        Vector3 endPoint = transform.position + transform.right * -maxDistance;
        hit2D = Physics2D.BoxCast(transform.position, Vector2.one * maxDistance, 0, endPoint, maxDistance);
        
        //if (hit2D.collider != null)
        //{
        //    endPoint = hit2D.collider;
        //}hit2D collider
        //render.positionCount = 2;
        //render.SetPositions(new Vector3[] {transform.position, endPoint});

        if (hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
                if (canFire)
                {
                             canFire = false;
                                     
                                 if (hit2D)
                                 {
                                     Fire();
                                     StartCoroutine(HelmetSpawnDelay());
                                 }
                }
                Debug.Log("Hit player");
        }
        
        //If enemy can fire
           
    }
    
    //Function for Helmet instantitation
    private void Fire()
    {
        Instantiate(helmetPrefab, spawnLocation.position, spawnLocation.rotation);
    }
    
    //Helmet Spawn Delay Coroutine
    IEnumerator HelmetSpawnDelay()
    {
        yield return new WaitForSeconds(2f);
        canFire = true;
    }
}
