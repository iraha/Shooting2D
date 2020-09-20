using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss3 : MonoBehaviour
{
    // Boss体力関連
    private float currentHealth;
    [SerializeField] float perCollision = 20;
    [SerializeField] float startHealth = 1000f;

    public Image healthBar;

    public GameObject damageExplosion;
    public GameObject dieExplosion;
    //Spaceship spaceship;

    //float offset;
    GameManagement gameManagement;


    public GameObject target;
    public GameObject eneShot01;
    int count = 0;

    // Use this for initialization
    void Start()
    {
        currentHealth = startHealth;
        target = GameObject.Find("Player");
        //spaceship = GetComponent<Spaceship>();

    }

    // Update is called once per frame
    void Update()
    {

        float shotSpeed = 5.0f;

        if (target == true)
        {
            if (count % 50 == 0)
            {
                for (int i = 0; i < 5; i++)
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

    // Playerにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {

            currentHealth = currentHealth - perCollision;

            healthBar.fillAmount = currentHealth / 1000f;

            Debug.Log(currentHealth);


            if (currentHealth >= 1)
            {
                //Destroy(collision.gameObject);
                //Explosion();
                Debug.Log(currentHealth);
                DamageExplosion();
            }
            else if (currentHealth <= 0)
            {
                // Boss の体力が0になると爆発する
                Debug.Log(currentHealth);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                DieExplosion();

                FindObjectOfType<GameManagement>().GameClear();
            }

            // Playerと当たった時にもExplosionFXが生成されるように設定
            //gameManagement.AddScore();


        }
        else if (collision.CompareTag("Enemy") == true)
        {

        }

    }

    private void DamageExplosion()
    {
        Instantiate(damageExplosion, transform.position, transform.rotation);
    }

    private void DieExplosion()
    {
        Instantiate(dieExplosion, transform.position, transform.rotation);
    }
}
