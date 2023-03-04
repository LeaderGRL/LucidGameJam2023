using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(IInteraction))]
public class ObjectInteraction : MonoBehaviour, IInteraction
{
    [field: SerializeField] public float interactionDistance { get; set; }
    [field: SerializeField] public Transform camera { get; set; }
    public bool isInteract { get; set; }

    public RaycastHit hit { get; set; }
    public bool isInteractable { get; set; }
    [field: SerializeField] public StarterAssetsInputs input { get; set; }
    [field: SerializeField] public GameObject interactionGUI { get; set; }
    [field: SerializeField] public TextMeshProUGUI interactionText { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        interactionGUI.SetActive(false);
        interactionText.text = "Press to steal";
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        isInteractable = Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hitInfo, interactionDistance);
        hit = hitInfo;
        Interact();
    }

    public void Interact()
    { 
        if (!isInteractable)
        {
            interactionGUI.SetActive(false);
            input.interact = false;
            return;
        }
        
        if (!hit.transform.gameObject.CompareTag("Object"))
        {
            input.interact = false;
            return;
        }
        
        ShowInteractionUI();

        if (!input.interact)
        {
            return;
        }

       

        hit.transform.gameObject.SetActive(false);
    }

    private void ShowInteractionUI()
    {
        interactionGUI.SetActive(true);
    }

}
