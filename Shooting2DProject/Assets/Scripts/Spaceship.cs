using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{

    // 移動スピード
    //public float speed;

    // ミサイルを撃つ間隔
    public float shotDelay;

    // 弾のPrefab
    public GameObject missile;

    // 弾を撃つかどうか
    public bool canShot;


    // 弾の作成
    public void Shot(Transform transform)
    {
        Instantiate(missile, transform.position, transform.rotation);
    }

    // 機体の移動
    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

    }

}
