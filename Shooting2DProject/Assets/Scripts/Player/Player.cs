using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Borders
{
    [Tooltip("offset from viewport borders for player's movement")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class Player : MonoBehaviour
{
    // Playerの動き部分
    [Tooltip("offset from viewport borders for player's movement")]
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true;

    public static Player instance;

    [SerializeField]float speed = 20f;

    // Playerミサイル関係
    public Transform firePoint;
    public GameObject missile;

    public GameObject explosion;

    public GameObject recoveryEX;

    // Playerの体力関連
    private float currentHealth;
    [SerializeField] float perCollision = 20;
    [SerializeField] float startHealth = 100f;

    public Slider slider;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();
        // sliderを定義
        slider.value = 1;

        currentHealth = startHealth;

        // missileを自動生成
        StartCoroutine(MissileShot());

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    // missileを自動生成
    IEnumerator MissileShot() 
    {
        while (true)
        {
            Instantiate(missile, firePoint.position, transform.rotation);
            yield return new WaitForSeconds(0.15f);

            

            //DestroyImmediate(missile, true);
        }
    }

    private void PlayerMovement()
    {
        /* 
        // 旧動きはここから⇩
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
        // ここまで↑
        */

        if (controlIsActive)
        {
#if UNITY_STANDALONE || UNITY_EDITOR    //if the current platform is not mobile, setting mouse handling 

            if (Input.GetMouseButton(0)) //if mouse button was pressed       
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //calculating mouse position in the worldspace
                mousePosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            }
#endif

#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 

            if (Input.touchCount == 1) // if there is a touch
            {
                Touch touch = Input.touches[0];
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);  //calculating touch position in the world space
                touchPosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
            }
#endif
            transform.position = new Vector3    //if 'Player' crossed the movement borders, returning him back 
                (
                Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),
                0
                );
        }

    }

    //setting 'Player's' movement borders according to Viewport size and defined offset
    void ResizeBorders()
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("Enemy") == true) 
        {
            if (currentHealth > 100f)
            {
                currentHealth = 100f;
                //Debug.Log(currentHealth);
            }

            currentHealth = currentHealth - perCollision;

            FindObjectOfType<GameManagement>().AddScore();

            slider.value = currentHealth / startHealth;

            if (currentHealth >= 1) 
            {
                //Destroy(collision.gameObject);
                //Explosion();
                //Debug.Log(currentHealth);
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

            //Debug.Log("Health回復" + currentHealth);
            RecoveryEX();
            slider.value = currentHealth / startHealth;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Weapon")) 
        {
            Debug.Log("ゲットWeapon");
            
            Invoke("MissileShot", 20);
            Destroy(collision.gameObject);

        }

    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void RecoveryEX() 
    {
        Instantiate(recoveryEX, transform.position, transform.rotation);
    }
}
