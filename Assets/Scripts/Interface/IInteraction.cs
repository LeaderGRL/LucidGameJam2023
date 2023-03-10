using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IInteraction
{
    [SerializeField]
    public float interactionDistance { get; set; }
    public Transform camera { get; set; }
    public RaycastHit hit { get; set; }
    public bool isInteract { get; set; }
    public bool isInteractable { get; set; }
    public StarterAssetsInputs input { get; set; }
    public GameObject interactionGUI { get; set; }
    public TextMeshProUGUI interactionText { get; set; }
}
