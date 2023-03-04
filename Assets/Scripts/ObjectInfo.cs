using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")]
public class ObjectInfo : ScriptableObject
{
    public int score;
    public float mass;
    public bool isInteractable;
}
