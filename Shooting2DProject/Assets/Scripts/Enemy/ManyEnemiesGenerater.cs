using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyEnemiesGenerater : MonoBehaviour
{
    public GameObject manyEnemies;
    public int spawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(manyEnemies, spawnPosition, transform.rotation);
    }
}
