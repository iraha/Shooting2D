using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile2 : MonoBehaviour
{

    //public GameObject explosion;

    void Update()
    {
        
        Destroy(gameObject, 6f);

    }


    
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {

            Explosion();
            Destroy(gameObject);
            //Destroy(collision.gameObject);

        }
        else if (collision.CompareTag("Enemy") == true)
        {

        }

    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    */
}
