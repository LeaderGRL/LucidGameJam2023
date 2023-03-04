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

    private float _remainingTime;

    private bool isEnd;

    public float RemainingTime
    {
        get { return _remainingTime; }
        set { 
            _remainingTime = value;
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
    
    // Start is called before the first frame update
    void Start()
    {
        ActualState = GameState.Tracking;
    }

    // Update is called once per frame
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

    private void ChangeGameState()
    {
        
        if (ActualState == GameState.Alarm)
        {
            GameOver();
            return;
        }
        ActualState = ActualState + 1;
    }

    public void GameOver()
    {
        RemainingTime = 0;
        isEnd = true;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
