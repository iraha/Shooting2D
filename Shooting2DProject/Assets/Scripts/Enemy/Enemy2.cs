using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public GameObject dieExplosion;

    public GameObject target;
    public GameObject eneShot01;
    int count = 0;


    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        float shotSpeed = 8.0f;

        if (target == true)
        {
            if (count % 50 == 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    Vector2 vec = target.transform.position - transform.position;
                    vec.Normalize();
                    vec = Quaternion.Euler(0, 0, (360 / 5) * i) * vec;
                    vec *= shotSpeed;
                    var t = Instantiate(eneShot01, transform.position, eneShot01.transform.rotation);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }

            }
            count++;
        }
        else if (target == false)
        {

        }
        
    }
}
