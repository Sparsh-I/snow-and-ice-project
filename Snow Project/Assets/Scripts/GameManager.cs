using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    public float highScore = 0f;
    public UnityEvent onGameOver = new UnityEvent();
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshProUGUI currentScoreUI;

    private void Start()
    {
        highScoreUI.SetText(PrettyScore(PlayerPrefs.GetFloat("HighScore", 0f)));
    }

    private void Update()
    {
        if (isPlaying)
            currentScore += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.K))
            isPlaying = true;
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        isPlaying = false;

        if (currentScore > PlayerPrefs.GetFloat("HighScore", 0f))
            PlayerPrefs.SetFloat("HighScore", currentScore);

        highScoreUI.SetText(PrettyScore(PlayerPrefs.GetFloat("HighScore", 0f)));
        currentScoreUI.SetText(PrettyScore());
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore * 100).ToString();
    }
    
    public string PrettyScore(float score)
    {
        return Mathf.RoundToInt(score * 100).ToString();
    }
}
