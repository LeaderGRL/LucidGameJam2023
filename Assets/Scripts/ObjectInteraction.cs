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
    public bool isInteractable { get; set; }
    [field: SerializeField] public StarterAssetsInputs input { get; set; }
    [field: SerializeField] public GameObject interactionGUI { get; set; }
    [field: SerializeField] public TextMeshProUGUI interactionText { get; set; }
    public bool isInteract { get; set; }
    public RaycastHit hit { get; set; }
    public TextMeshProUGUI scoreUI;
    public Player player;



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

        player.score += hit.transform.gameObject.GetComponent<Object>().info.score;
        Debug.Log(hit.transform.gameObject.GetComponent<Object>().info.score);
        hit.transform.gameObject.SetActive(false);
        scoreUI.text = player.score.ToString();
        return;
        //scoreUI.text 
    }

    private void ShowInteractionUI()
    {
        interactionGUI.SetActive(true);
    }

}
