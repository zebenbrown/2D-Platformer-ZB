using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helemt : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 1f;
    private float life = 0f;
    private Rigidbody2D helmetRb;

    // Start is called before the first frame update
    void Start()
    {
        helmetRb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector3 leftInput =  new Vector3(-1, 0, 0);
        
        helmetRb.AddForce(-transform.right * speed);
    }
    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
