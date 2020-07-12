using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {

        // InvokeRepeating("この関数を呼び出す", 秒後に, 秒刻みで)
        InvokeRepeating("Spawn", 4f, 3f);

    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-3.5f, 3.5f),
            transform.position.y,
            transform.position.z
            );

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, transform.rotation);
    }
}
