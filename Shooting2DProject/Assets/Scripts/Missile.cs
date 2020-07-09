using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    [SerializeField] float speed = 15f;


    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;

        //Destroy(gameObject, 3f);
    }
}
