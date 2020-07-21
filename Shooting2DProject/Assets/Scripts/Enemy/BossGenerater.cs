﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerater : MonoBehaviour
{

    public GameObject boss; 
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);

        Instantiate(boss, spawnPosition, transform.rotation);
    }
}
