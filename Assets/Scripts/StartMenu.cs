using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject TutoPanel;

    public void Play()
    {
        SceneManager.LoadScene("Playground");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    public void Tuto()
    {
        TutoPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
