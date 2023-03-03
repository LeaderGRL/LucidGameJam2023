using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{
    public float interactionDistance { get; set; }
    public Transform camera { get; set; }
    public RaycastHit hit { get; }
    public bool isInteract { get; set; }
}
