using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] waves;

    private int currentWave;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (waves.Length == 0) 
        {
            yield break;
        }
        // Waveを作成
        GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);

        wave.transform.parent = transform;
        while (wave.transform.childCount != 0) 
        {
            yield return new WaitForEndOfFrame();
        }

        Destroy(wave, 4f);

        if (waves.Length <= ++currentWave) 
        {
            currentWave = 0;
        }
        
    }

}
