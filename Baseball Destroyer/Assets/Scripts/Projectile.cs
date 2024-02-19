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

    public bool playerDetected;
    //[SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask playerLayerMask;
    private RaycastHit2D hit2D;
    [SerializeField] private LineRenderer render;
    [SerializeField] private float maxDistance = 10f;
    
    private void FixedUpdate()
    {
        Vector3 endPoint = transform.position + transform.right * -maxDistance;
        hit2D = Physics2D.Raycast(transform.position, Vector2.left, maxDistance, playerLayerMask);
        //Enemy can throw helmets
        if (canFire)
        {
            //Box cast detected player
            if (hit2D.collider != null && hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                //Player Detected
                playerDetected = true;
                //Fire Helmets
                Fire();
                //Cannot fire helmets
                canFire = false;
                //Start Helmet throwing delay
                StartCoroutine(HelmetSpawnDelay()); 
                Debug.Log("Hit player");
            }
            
        }

    }
    
    //Function for Helmet instantiation
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
