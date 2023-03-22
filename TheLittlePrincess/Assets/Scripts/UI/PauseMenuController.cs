using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : IMenuController
{
    public MenuButtonController _pauseMenuController;
    public MenuButtonController _optionsMenuController;

    private bool paused = false;
    private float _waitBetweenActions = 0.7f;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    override
    public void PressButton(int indexButton, string context)
    {
        if (context.Equals(_pauseMenuController.context))
        {
            DoActionPauseMenu(indexButton);
        }
        else if (context.Equals(_optionsMenuController.context))
        {
            DoActionOptionsMenu(indexButton);
        }
    }

    private void DoActionPauseMenu(int indexButton)
    {
        switch (indexButton)
        {
            case 0:
                Resume();
                break;
            case 1:
                ShowOptions();
                break;
            case 2:
                StartCoroutine(BackToMainMenu());
                break;
        }
    }

    private void DoActionOptionsMenu(int indexButton)
    {
        switch (indexButton)
        {
            case 0:
                Pause();
                break;
        }
    }

    private void Pause()
    {
        _pauseMenuController.Activate();
        _optionsMenuController.DeActivate();
        Time.timeScale = 0f;
        paused = true;
    }

    private void Resume()
    {
        _pauseMenuController.DeActivate();
        _optionsMenuController.DeActivate();
        Time.timeScale = 1f;
        paused = false;
    }

    private void ShowOptions()
    {
        _pauseMenuController.DeActivate();
        _optionsMenuController.Activate();
    }

    private IEnumerator BackToMainMenu()
    {
        Debug.Log("Back to main menu");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_waitBetweenActions);
        SceneManager.LoadScene(0);
    }
}
