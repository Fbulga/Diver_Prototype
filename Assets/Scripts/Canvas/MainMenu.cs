using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
