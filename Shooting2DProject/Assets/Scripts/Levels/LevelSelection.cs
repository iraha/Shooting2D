using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public SceneFader fader;

    public Button[] levelButtons;
    public GameObject unlockImage;

    void Start() 
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++) 
        {
            if (i+1 > levelReached) 
            {
                levelButtons[i].interactable = false;
                
            }
            
        }

        PlayerPrefs.Save();
        
    }

    public void Select (string levelName) 
    {
        fader.FadeTo(levelName);
    }

}
