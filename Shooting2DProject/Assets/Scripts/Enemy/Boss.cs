using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    // Boss体力関連
    private float currentHealth;
    [SerializeField] float perCollision = 20;
    [SerializeField] float startHealth = 1000f;

    public Image healthBar;


    public GameObject explosion;
    Spaceship spaceship;

    //float offset;

    GameManagement gameManagement;


    IEnumerator Start()
    {

        currentHealth = startHealth;
        spaceship = GetComponent<Spaceship>();

        // gameManagementにヒエラルキー上のGemaMangement、Objectの中のGameManagementをGetComponentで取得
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();

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

    // Enemyにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {

            currentHealth = currentHealth - perCollision;

            healthBar.fillAmount = currentHealth / 1000f;

            if (currentHealth >= 1)
            {
                //Destroy(collision.gameObject);
                //Explosion();
                Debug.Log(currentHealth);
            }
            else if (currentHealth <= 0)
            {
                Debug.Log(currentHealth);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);

                FindObjectOfType<GameManagement>().GameClear();
            }
            // Playerと当たった時にもExplosionFXが生成されるように設定
            //Instantiate(explosion, collision.transform.position, transform.rotation);

            gameManagement.AddScore();


        } 
        else if (collision.CompareTag("Enemy") == true)
        {

        }

    }


}
