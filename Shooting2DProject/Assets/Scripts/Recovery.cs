using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{

    public float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        MeteoriteMovement();
    }

    private void MeteoriteMovement()
    {
        transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }


}
