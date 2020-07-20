using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]float speed = 8f;

    public Transform firePoint;
    public GameObject missile;

    public GameObject explosion;

    // Playerの体力関連
    private float currentHealth;
    [SerializeField] float perCollision = 20;
    [SerializeField] float startHealth = 100f;

    public Slider slider;


    //GameManagement gameManagement;


    // missileを自動生成
    IEnumerator Start()
    {
        // sliderを定義
        slider.value = 1;

        currentHealth = startHealth;

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

        Vector3 direction = new Vector3(x, y, 0);

        Vector3 validPosition = transform.position + direction * Time.deltaTime * speed;

        // playerの動ける範囲を制御
        validPosition = new Vector3(
            Mathf.Clamp(validPosition.x, -5f, 5f),
            Mathf.Clamp(validPosition.y, -9f, 7.5f),
            validPosition.z
        );

        transform.position = validPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("Enemy") == true) 
        {
            if (currentHealth > 100f)
            {
                currentHealth = 100f;
                Debug.Log(currentHealth);
            }

            currentHealth = currentHealth - perCollision;

            FindObjectOfType<GameManagement>().AddScore();

            slider.value = currentHealth / startHealth;

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
                Explosion();
                Destroy(gameObject);

                FindObjectOfType<GameManagement>().GameOver();
            }

        }
        else if (collision.CompareTag("Recovery")) 
        {
            currentHealth = currentHealth + 20;
            
            Debug.Log("Health回復" + currentHealth);

            slider.value = currentHealth / startHealth;
            Destroy(collision.gameObject);
        }

    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
