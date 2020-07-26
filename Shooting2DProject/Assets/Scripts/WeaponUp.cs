using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUp : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        WeaponUpMovement();
    }

    private void WeaponUpMovement()
    {
        transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.tag == "Player")
        {
            if (PlayerShooting.instance.weaponPower < PlayerShooting.instance.maxweaponPower)
            {
                PlayerShooting.instance.weaponPower++;
            }
            Destroy(gameObject);
        }
        */
    }

}
