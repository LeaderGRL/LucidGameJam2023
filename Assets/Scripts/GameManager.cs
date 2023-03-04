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
            RemainingTimeUI.text = value.ToString("0.00");
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        RemainingTime = 60f;
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
            GameOver();
            return;
        }
    }

    public void GameOver()
    {
        RemainingTime = 0;
        isEnd = true;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
