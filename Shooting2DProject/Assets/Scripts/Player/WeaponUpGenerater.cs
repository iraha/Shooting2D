﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpGenerater : MonoBehaviour
{
    public GameObject weaponUp;

    // Start is called before the first frame update
    void Start()
    {

        // InvokeRepeating("この関数を呼び出す", 秒後に, 秒刻みで)
        InvokeRepeating("Spawn", 10f, 10f);
        //Spawn();
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-3.5f, 3.5f),
            transform.position.y,
            transform.position.z
            );

        Instantiate(weaponUp, spawnPosition, transform.rotation);
    }
}
