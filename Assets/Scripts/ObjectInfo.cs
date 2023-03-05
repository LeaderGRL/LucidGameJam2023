using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")]
public class ObjectInfo : ScriptableObject
{
    public int id;
    public float mass;
    public int score;
    public float time;
    public bool isInteractable;
}
