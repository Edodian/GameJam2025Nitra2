using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject PauseMenu, SceneUi, OptionsMenu;
    public stateHandler stateHandler;
    public bool isChangedPause;

    void Start()
    {
        stateHandler.isPaused = false;
        stateHandler.isCompleted = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenu.SetActive(false);
        if (SceneUi != null)
        {
            SceneUi.SetActive(true);
        }
    }

    void Update()
    {
        if (!stateHandler.isCompleted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TriggerPause();
            }
        }
    }

    void gamepause()
    {
        if (SceneUi != null)
        {
            SceneUi.SetActive(false);
        }
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

    }

    void gameOver()
    {
        Time.timeScale = 0;
        stateHandler.isCompleted = true;
    }

    public void gamecontinue()
    {
        stateHandler.isPaused = false;
        if (SceneUi != null)
        {
            SceneUi.SetActive(true);
        }
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        OptionsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("game continues");
    }

    public void LoadMainMenu()
    {
        gamecontinue();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void RestartGame()
    {
        gamecontinue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TriggerPause()
    {
        StartCoroutine(SetIsChangedPause());
        stateHandler.isPaused = !stateHandler.isPaused;

        if (stateHandler.isPaused)
        {
            gamepause();
        }
        else
        {
            gamecontinue();
        }
    }

    private IEnumerator SetIsChangedPause()
    {
        isChangedPause = true; 
        yield return new WaitForSecondsRealtime(0.1f); 
        isChangedPause = false; 
    }
}
