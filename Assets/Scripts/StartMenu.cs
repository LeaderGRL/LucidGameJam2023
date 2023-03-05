using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject TutoPanel;
    public GameObject Buttons;

    public void Play()
    {
        SceneManager.LoadScene("Playground");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    public void Tuto()
    {
        TutoPanel.SetActive(true);
        Buttons.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnFromTuto()
    {
        TutoPanel.SetActive(false);
        Buttons.SetActive(true);
    }
}
