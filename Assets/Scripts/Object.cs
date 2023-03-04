using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public ObjectInfo info;
    public float RemainingTime;
    void Start()
    {
        RemainingTime = info.time;
    }

}
