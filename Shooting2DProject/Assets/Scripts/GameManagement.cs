﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagement : MonoBehaviour
{
    // スコア関連の関数
    public Text scoreText;
    int gameScore = 0;

    // タイマー関連
    public Text timerText;

    public float gameTime = 60f;
    int seconds;

    // Pause関連の関数
    public GameObject gamePauseUI;
    public GameObject pauseButton;

    // GameOver関連の関数
    public GameObject gameOverUI;

    // GameClear関連の関数
    public GameObject gameClearUI;
    public GameObject healthBarBackground;

    // NextLevel関連
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;


    // BGM関連
    private AudioSource audioSource;
    public AudioClip BGM;

    public SceneFader sceneFader;
    // ステージレベル関連
    //public GameObject guiObject;
    //public string levelToLoad;

    // Start is called before the first frame update 
    void Start()
    {

        scoreText.text = "SCORE: " + gameScore;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BGM;
        audioSource.Play();

        //nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeManagement();
        //GamePause();
    }

    public void AddScore()
    {
        gameScore += 50;
        scoreText.text = "SCORE: " + gameScore;

    }

    // タイマーの設定
    public void TimeManagement()
    {

        gameTime -= Time.deltaTime;
        seconds = (int)gameTime;
        timerText.text = seconds.ToString();

        if (seconds == 0)
        {
            Debug.Log("TimeOut");
            GameOver();
            Time.timeScale = 1f;
            //FindObjectOfType<GameOver>().EndGame();
        }
    }

    public void GamePause()
    {

        gamePauseUI.SetActive(!gamePauseUI.activeSelf);
        healthBarBackground.SetActive(false);
        
        if (gamePauseUI.activeSelf)
        {
            // gamePauseUIが表示されている間はゲームを停止
            Time.timeScale = 0f;
        }
        else
        {
            // gamePauseUIが表示されてなければ通常通り
            Time.timeScale = 1f;
            healthBarBackground.SetActive(true);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        pauseButton.SetActive(false);
        healthBarBackground.SetActive(false);
        audioSource.Stop();

        if (gameOverUI.activeSelf)
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void GameClear()
    {
        gameClearUI.SetActive(true);
        pauseButton.SetActive(false);
        healthBarBackground.SetActive(false);

        audioSource.Stop();

        if (gameClearUI.activeSelf)
        {
            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void Retry()
    {
        //SceneManager.LoadScene(scene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Level_Selection");
        Time.timeScale = 1f;
    }

    public void WinLevel()
    {
        Debug.Log("Level Win");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
        Time.timeScale = 1f;
    }

    /*
    public void NextLevel() 
    {
        //PlayerPrefs.SetInt("leveLReached", levelToUnlock);
        
        SceneManager.LoadScene(nextLevel);

        if (nextLevel > PlayerPrefs.GetInt("levelAt")) 
        {
            PlayerPrefs.SetInt("levelAt", nextLevel);

        }

    }
    */

}
