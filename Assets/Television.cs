using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour, IInteraction
{
    [field: SerializeField] public float interactionDistance { get; set; }
    [field: SerializeField] public Transform camera { get; set; }
    public bool isInteractable { get; set; }
    [field: SerializeField] public StarterAssetsInputs input { get; set; }
    [field: SerializeField] public GameObject interactionGUI { get; set; }
    [field: SerializeField] public TextMeshProUGUI interactionText { get; set; }
    public RaycastHit hit { get; set; }
    public bool isInteract { get; set; }

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


        Interact();
    }

    private void Interact()
    {
        
        if (_isInteracted )
        {
            return;
        }

        if (!isInteractable)
        {
            interactionGUI.SetActive(false);
            return;
        }
        if (hit.transform.gameObject.CompareTag("Object"))
        {
            return;
        }

        if (hit.transform.gameObject != gameObject && !hit.transform.gameObject.CompareTag("Object") )
        {
            interactionGUI.SetActive(false);
            return;
        }



        ShowInteractionUI();

        if (!input.interact)
        {
            return;
        }

        if (GameManager.Instance.ActualState == GameState.Tracking)
        {
            GameManager.Instance.ChangeGameState();

        }
        GetComponent<VideoPlayer>().enabled = true;
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        interactionGUI.SetActive(false);
        _isInteracted= true;


    }

    private void ShowInteractionUI()
    {
        interactionGUI.SetActive(true);
        interactionText.text = "Appuyer pour voler";
    }
}
