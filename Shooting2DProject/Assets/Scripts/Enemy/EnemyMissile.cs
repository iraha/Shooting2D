﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    public GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        //transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        Destroy(gameObject, 3f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            //Destroy(collision.gameObject);
            Explosion();
            Destroy(gameObject);
            Destroy(collision.gameObject);

            
        }

    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
