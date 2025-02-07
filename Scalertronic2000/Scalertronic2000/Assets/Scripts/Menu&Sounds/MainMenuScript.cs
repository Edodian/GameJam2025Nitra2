using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    void Start()
    {
        MainMenu.SetActive(true);
        SoundManager.sndm.StopAllSounds();
        SoundManager.sndm.Play("MainTheme");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {

    }
    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("LelvelsPassed", 0);
    }
    public void BeginGame()
    {
        SceneManager.LoadScene("Entry");
    }

}

