using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmPointLight : MonoBehaviour
{
    public float SwitchTime;
    private float _remainingTime;

    private void Start()
    {
        _remainingTime = 0;
    }

    void Update()
    {
        if (GameManager.Instance.ActualState != GameState.Alarm)
        {
            return;
        }
        _remainingTime += Time.deltaTime;
        if (_remainingTime >= SwitchTime)
        {
            _remainingTime = 0;
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            
        }
    }
}
