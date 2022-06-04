using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PressPlay ()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PressQuit ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
