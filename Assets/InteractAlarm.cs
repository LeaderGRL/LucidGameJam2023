using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractAlarm : MonoBehaviour, IInteraction
{
    [field: SerializeField] public float interactionDistance { get; set; }
    [field: SerializeField] public Transform camera { get; set; }
    public bool isInteractable { get; set; }
    [field: SerializeField] public StarterAssetsInputs input { get; set; }
    [field: SerializeField] public GameObject interactionGUI { get; set; }
    [field: SerializeField] public TextMeshProUGUI interactionText { get; set; }
    public RaycastHit hit { get ; set ; }
    public bool isInteract { get ; set ; }

    private bool _isInteracted;

    private void Start()
    {
        _isInteracted = false;
    }

    private void Update()
    {
        RaycastHit hitInfo;
        isInteractable = Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hitInfo, interactionDistance);
        hit = hitInfo;
        isInteract = input.interact;
        Interact();
    }

    private void Interact()
    {
        if (_isInteracted || GameManager.Instance.ActualState == GameState.Alarm)
        {
            return;
        }

        if (!isInteractable) 
        {
            interactionGUI.SetActive(false);
            return;
        }

        if (hit.transform.gameObject != gameObject)
        {
            return;
        }

        ShowInteractionUI();

        if (!isInteract)
        {
            return;
        }
        Debug.Log("Test");

        GameManager.Instance.ChangeGameState();
        interactionGUI.SetActive(false);


    }

    private void ShowInteractionUI()
    {
        interactionGUI.SetActive(true);
    }
}
