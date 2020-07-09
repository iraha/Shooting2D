using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float speed = 5f;

    public Transform firePoint;
    public GameObject missile;



    // missileを自動生成
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(missile, firePoint.position, transform.rotation);
            yield return new WaitForSeconds(0.15f);

            //DestroyImmediate(missile, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // Playerの動き
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 validPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * speed;

        // playerの動ける範囲を制御
        validPosition = new Vector3(
            Mathf.Clamp(validPosition.x, -3f, 3f),
            Mathf.Clamp(validPosition.y, -6f, 5f),
            validPosition.z
        );

        transform.position = validPosition;
    }
}
