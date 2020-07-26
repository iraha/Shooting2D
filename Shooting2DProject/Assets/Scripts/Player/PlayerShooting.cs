using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

[System.Serializable]
public class Missiles
{
    public GameObject rightMissile, leftMissile, centerMissile;
    //[HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX;
}

public class PlayerShooting : MonoBehaviour
{

    // weapon 関連
    public float fireRate = 5f;

    [Tooltip("projectile prefab")]
    public GameObject projectileObject;

    //time for a new shot
    [HideInInspector] public float nextFire;

    [Range(1, 4)] public int weaponPower = 1;

    public Missiles missiles;
    bool shootingIsActive = true;
    [HideInInspector] public int maxweaponPower = 4;

    public static PlayerShooting instance;


    // Start is called before the first frame update
    void Start()
    {
        // missilesコンポーネントを取得
        missiles.leftMissile.GetComponent<GameObject>();
        missiles.rightMissile.GetComponent<GameObject>();
        missiles.centerMissile.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingIsActive)
        {
            if (Time.time > nextFire)
            {
                MakeMissile();
                nextFire = Time.time + 1 / fireRate;
            }
        }
    }

    void MakeMissile() 
    {
        switch (weaponPower) 
        {
            case 1:
                MissileShot(projectileObject, missiles.centerMissile.transform.position, Vector3.zero);
                //missiles.centerMissile.Play();
                break;
            case 2:
                MissileShot(projectileObject, missiles.leftMissile.transform.position, Vector3.zero);
                MissileShot(projectileObject, missiles.rightMissile.transform.position, Vector3.zero);
                break;


        }
    }

    void MissileShot(GameObject missile, Vector3 pos, Vector3 rot)
    {

        Instantiate(missile, pos, Quaternion.Euler(rot));

    }
}

*/
