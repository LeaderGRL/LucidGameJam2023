
using System;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool _isOn = true;
    public bool IsOn
    {
        get { return _isOn;}
        set { _isOn = value; }
    }
    [SerializeField] private GameObject lightSource;
    public void SwitchTorch()
    {
        lightSource.SetActive(IsOn);
    }
  
}
