using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] public float speed = 0.5f;
    public GameObject explosion;

    Spaceship spaceship;

    float offset;

    // AddScore取得のため gameManagementを追加
    GameManagement gameManagement;

    IEnumerator Start() 
    {

        spaceship = GetComponent<Spaceship>();

        // gameManagementにヒエラルキー上のGemaMangement、Objectの中のGameManagementをGetComponentで取得
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();

        offset = Random.Range(0, Mathf.PI);

        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (spaceship.canShot == false) 
        {
            yield break;
        }

        while (true) 
        {

            for (int i = 0; i < transform.childCount; i++) 
            {
                Transform shotPosition = transform.GetChild(i);
                spaceship.Shot(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        Destroy(gameObject, 15f);
    }

    private void EnemyMovement()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount * 0.03f + offset) * 0.03f,
            speed * Time.deltaTime,
            0);
    }

    // public void Shot(Transform transform)
    // {
    //     Instantiate(missile, transform.position, transform.rotation);
    // }

    // Enemyにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            // Playerと当たった時にもExplosionFXが生成されるように設定
            //Instantiate(explosion, collision.transform.position, transform.rotation);
            DieExplosion();

            Destroy(gameObject);

            gameManagement.AddScore();


        } // Enemyがmissileにぶつかった時のみAddscoreされ
        else if (collision.CompareTag("Enemy") == true)
        {

        }

    }

    private void DieExplosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

}
