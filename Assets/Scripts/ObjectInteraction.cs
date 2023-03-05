using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(IInteraction))]
public class ObjectInteraction : MonoBehaviour, IInteraction
{
    [field: SerializeField] public float interactionDistance { get; set; }
    [field: SerializeField] public Transform camera { get; set; }
    public bool isInteractable { get; set; }
    [field: SerializeField] public StarterAssetsInputs input { get; set; }
    [field: SerializeField] public GameObject interactionGUI { get; set; }
    [field: SerializeField] public TextMeshProUGUI interactionText { get; set; }
    [SerializeField] private GameObject wall;
    public bool isInteract { get; set; }
    public RaycastHit hit { get; set; }
    public TextMeshProUGUI scoreUI;
    public Player player;
    public FirstPersonController fps;
    public ClipBoard clipBoard;
    public Slider slider;



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
            slider.value = -1;
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
            hit.transform.GetComponent<Object>().RemainingTime = hit.transform.GetComponent<Object>().info.time;
            slider.value = -1;

            return;
        }





        PickObject(hit.transform.GetComponent<Object>());
        return;
        //scoreUI.text 
    }

    private void PickObject(Object obj)
    {
        if (obj.RemainingTime <= 0)
        {
            GetObject(obj);
            return;
        }
        obj.RemainingTime -= Time.deltaTime;
        slider.value = -obj.RemainingTime / obj.info.time;
    }

    private void GetObject(Object obj)
    {
        player.score += obj.info.score;
        player.mass+= obj.info.mass / 3000;
        fps.MoveSpeed -= obj.info.mass / 3000;
        fps.SprintSpeed -= obj.info.mass / 3000;
        fps.MoveCrouchSpeed -= obj.info.mass / 3000;
        obj.gameObject.SetActive(false);
        if (clipBoard.CheckTask(obj.info.id))
        {
            player.score += obj.info.score / 10;
        }

        if (clipBoard.CheckForEasterEgg(obj.info.id))
        {
            wall.SetActive(false);
        }
        scoreUI.text = "score : " + player.score.ToString();
        slider.value = -1;

        if (fps.MoveSpeed < 1.5f)
        {
            fps.MoveSpeed = 1.5f;
        }
        if (fps.MoveCrouchSpeed < 0.75f)
        {
            fps.MoveCrouchSpeed = 0.75f;
        }
        if (fps.SprintSpeed < 2f)
        {
            fps.SprintSpeed = 2f;
        }
    }

    private void ShowInteractionUI()
    {
        interactionGUI.SetActive(true);
        interactionText.text = "Appuyer pour voler";
    }

}
