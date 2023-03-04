using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscretionScript : MonoBehaviour
{
    public Slider slider;

    private float _discretionGauge;

    public float DiscretionGauge
    {
        get { return _discretionGauge; }
        set { 
            _discretionGauge = value; 
            slider.value = _discretionGauge;
        }
    }

    private Vector3 previousPosition;

    

    private void Start()
    {
        previousPosition= transform.position;
    }

    void Update()
    {
        float sqrLen = (transform.position - previousPosition).sqrMagnitude;
        previousPosition= transform.position;
        DiscretionGauge = sqrLen * 500000;
    }
}
