﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{

    [SerializeField] public float speed = 2f;
    [SerializeField] public GameObject explosion;

    float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeteoriteMovement();
    }

    private void MeteoriteMovement()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.03f + offset) * 0.001f,
            speed * Time.deltaTime,
            0f);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("Player") == true)
        {
            // Playerと当たった時にもExplosionFXが生成されるように設定
            Instantiate(explosion, collision.transform.position, transform.rotation);
            // Enemyにオブジェクトがあたったら、Explosionが生成
            Instantiate(explosion, transform.position, transform.rotation);

        } // Enemyがmissileにぶつかった時のみAddscoreされる
        else if (collision.CompareTag("Enemy") == true)
        {
            //gameManagement.AddScore();
            
        }

    }

}