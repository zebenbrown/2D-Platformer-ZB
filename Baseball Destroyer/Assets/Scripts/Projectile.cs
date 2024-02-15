using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject helmetPrefab;
    private bool canFire = true;
    public LayerMask layersToHit;
    private RaycastHit2D hit2D;
    
    private void FixedUpdate()
    {
        hit2D = Physics2D.Raycast(transform.position, Vector3.left, 100);
        //If enemy can fire
            if (canFire)
            {
                canFire = false;
                        
                    if (hit2D)
                    {
                        Fire();
                        StartCoroutine(HelmetSpawnDelay());
                    }
            }
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
