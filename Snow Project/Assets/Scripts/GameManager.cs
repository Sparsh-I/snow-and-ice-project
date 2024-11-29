using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    #endregion Singleton

    public float currentScore = 0f;
    public bool isPlaying = false;

    private void Update()
    {
        if (isPlaying)
            currentScore += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.K))
            isPlaying = true;
    }

    public void GameOver()
    {
        currentScore = 0;
        isPlaying = false;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore * 100).ToString();
    }
}
