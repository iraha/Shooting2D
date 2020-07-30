using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] public float speed = 0.5f;
    public GameObject explosion;

    Spaceship spaceship;

    // AddScore取得のため gameManagementを追加
    GameManagement gameManagement;

    float offset;

    IEnumerator Start()
    {

        spaceship = GetComponent<Spaceship>();

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
            Mathf.Cos(Time.frameCount + offset) * 0.0f,
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
            Instantiate(explosion, collision.transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);

            //gameManagement.AddScore();

        } // Enemyがmissileにぶつかった時のみAddscoreされ
        else if (collision.CompareTag("Enemy") == true)
        {

        }

        // Enemyにミサイルが当たるとデストロイ
        //Destroy(gameObject);

        // Enemyにあったオブジェクトもデストロイ
        //Destroy(collision.gameObject);

        // Enemyにオブジェクトがあたったら、ExplosionFXが生成

    }
}
