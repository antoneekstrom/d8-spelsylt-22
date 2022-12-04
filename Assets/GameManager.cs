using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject levelCleared;
    public GameObject gameCleared;
    public TMP_Text totalTimeText;
    private float totalTime = 0;

    public TMP_Text timer;
    private float levelTime = 60;

    public LevelManager levelManager;
    public GameObject[] levels;
    private int levelCount = 0;

    private bool isPlaying = true;

    private void Update()
    {
        if (isPlaying)
        {
            levelTime -= Time.deltaTime;
            totalTime += Time.deltaTime;
            float minutes = Mathf.FloorToInt(levelTime / 60);
            float seconds = Mathf.FloorToInt(levelTime % 60);
            timer.text = string.Format("{0:00}.{1:00}", minutes, seconds);
            if (levelTime <= 0)
            {
                GameOver();
                timer.text = ("00:00");
            }
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void OnGameRestart()
    {
        gameOverScreen.SetActive(false);
        gameCleared.SetActive(false);
        isPlaying = true;
        levelTime = 60;
        totalTime = 0;
        levelCount = 0;
        //levels[0].GetComponent<FieldRandomizer>().Generate();
        levelManager.Restart();
    }

    public void OnLevelCleared()
    {
        levelCleared.SetActive(true);
    }

    public void OnNextLevel()
    {
        levelCount++;

    }

    public void OnGameCleared()
    {
        DisplayTotalTime(totalTime);
    }

    void DisplayTotalTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        totalTimeText.text = string.Format("It took {0:00}.{1:00} minutes to complete", minutes, seconds);
    }
}
