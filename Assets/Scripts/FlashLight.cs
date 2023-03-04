
using System;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool _isOn = true;
    [SerializeField] private GameObject lightSource;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public bool IsOn
    {
        get { return _isOn;}
        set { _isOn = value; }
    }
    public void SwitchTorch()
    {
        _audioSource.Play();
        lightSource.SetActive(IsOn);
    }
  
}
