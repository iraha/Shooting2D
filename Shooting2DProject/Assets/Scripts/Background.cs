using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * speed);
        // if (transform.position.y <= -8.5f)
        // {
        //     transform.position = new Vector2(0, 13.0f);
        // }
    }
}
