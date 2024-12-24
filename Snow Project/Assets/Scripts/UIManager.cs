using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject gameOverUI;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameOverUI.SetActive(false);
        gameManager.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    private void OnGUI()
    {
        scoreUI.text = gameManager.PrettyScore();
    }
}
