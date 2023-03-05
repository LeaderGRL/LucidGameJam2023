using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI RemainingTimeUI;
    public GameObject GameOverPanel;
    public static GameManager Instance;
    public GameObject RemainingTimeImage;
    public AudioSource audioSource;

    private float _remainingTime;

    private bool isEnd;

    public float RemainingTime
    {
        get { return _remainingTime; }
        set { 
            _remainingTime = value;
            if (ActualState != GameState.Alarm)
            {
                return;
            }
            RemainingTimeUI.text = Math.Round(value, 0, MidpointRounding.AwayFromZero).ToString();
        }
    }

    private GameState _actualState;

    public GameState ActualState
    {
        get { return _actualState; }
        set { 
            _actualState= value;
            RemainingTime = 60f;
        }
    }

    private void Awake()
    {
        // A : Je m'initialise

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        ActualState = GameState.Tracking;
    }

    void Update()
    {
        
        if (isEnd)
        {
            return;
        }

        RemainingTime -= Time.deltaTime;

        if (RemainingTime <= 0)
        {
            ChangeGameState();
            return;
        }
    }

    public void ChangeGameState()
    {
        
        if (ActualState == GameState.Alarm)
        {
            GameOver();
            RemainingTimeImage.SetActive(false);
            return;
        }
        RemainingTimeImage.SetActive(true);
        ActualState = ActualState + 1;
        RemainingTimeUI.color = Color.red;
        audioSource.enabled = true;
    }

    public void GameOver()
    {
        RemainingTime = 0;
        isEnd = true;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        audioSource.enabled = false;
    }
}
