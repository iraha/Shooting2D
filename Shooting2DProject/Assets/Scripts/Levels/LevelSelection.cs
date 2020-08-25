using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    //public SceneFader fader;

    // levelのボタン
    public Button[] levelButtons;

    // Loading関連
    [SerializeField] private Text loadingText;
    [SerializeField] Slider slider;

    public GameObject LoadingUI;

    void Start() 
    {

        LoadingUI.SetActive(false);

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++) 
        {
            if (i+1 > levelReached) 
            {
                levelButtons[i].interactable = false;       
            }
            
        }
        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
    }

    public void Select (string levelName) 
    {
        //fader.FadeTo(levelName);
        SceneManager.LoadScene(levelName);
        LoadingUI.SetActive(true);

    }

    private IEnumerator BeginLoading(string levelName) 
    {
        //LoadingUI.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        

        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            //Debug.Log(progress);
            
            yield return null;
        }

    }

}
