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

}
