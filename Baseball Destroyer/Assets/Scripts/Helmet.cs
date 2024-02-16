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
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        helmetRb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        helmetRb.AddForce(-transform.right * speed);
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward, rotation * Time.deltaTime);
        life += Time.deltaTime;
        if (life >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
