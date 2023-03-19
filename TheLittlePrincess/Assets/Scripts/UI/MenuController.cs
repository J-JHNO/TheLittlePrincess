using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public MenuButtonController _mainMenuController;
    public MenuButtonController _planetMenuController;
    public MenuButtonController _optionsMenuController;
    public PlanetLoader _planetLoader;

    private float _waitBetweenActions = 0.7f;
    private bool _loadingPlanet = false;

    public void PressButton(int indexButton, string context)
    {
        if (context.Equals(_mainMenuController.context))
        {
            DoActionMainMenu(indexButton);
        }
        else if (context.Equals(_planetMenuController.context))
        {
            DoActionPlanetSelectorMenu(indexButton);
        }
        else if (context.Equals(_optionsMenuController.context))
        {
            DoActionOptionsMenu(indexButton);
        }
    }

    public void DoActionMainMenu(int indexButton)
    {
        switch (indexButton)
        {
            case 0:
                StartCoroutine(ShowSelectorPlanetMenu());
                break;
            case 1:
                StartCoroutine(ShowOptions());
                break;
            case 2:
                StartCoroutine(Quit());
                break;
        }
    }

    public void DoActionPlanetSelectorMenu(int indexButton)
    {
        switch (indexButton)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                StartCoroutine(StartPlanet(indexButton));
                break;
            case 4:
                StartCoroutine(ShowMainMenu()); // Back Button
                break;
        }
    }

    public void DoActionOptionsMenu(int indexButton)
    {
        switch (indexButton)
        {
            case 0:
                StartCoroutine(ShowMainMenu()); // Back Button
                break;
        }
    }

    public IEnumerator ShowSelectorPlanetMenu()
    {
        Debug.Log("Show planet selector menu");
        yield return new WaitForSeconds(_waitBetweenActions);
        _mainMenuController.DeActivate();
        _optionsMenuController.DeActivate();
        yield return new WaitForSeconds(_waitBetweenActions);
        _planetMenuController.Activate();
    }

    public IEnumerator ShowMainMenu()
    {
        Debug.Log("Show main menu");
        yield return new WaitForSeconds(_waitBetweenActions);
        _planetMenuController.DeActivate();
        _optionsMenuController.DeActivate();
        yield return new WaitForSeconds(_waitBetweenActions);
        _mainMenuController.Activate();
    }

    public IEnumerator ShowOptions()
    {
        Debug.Log("Show options");
        yield return new WaitForSeconds(_waitBetweenActions);
        _mainMenuController.DeActivate();
        _planetMenuController.DeActivate();
        yield return new WaitForSeconds(_waitBetweenActions);
        _optionsMenuController.Activate();
    }

    public IEnumerator Quit()
    {
        Debug.Log("Quit");
        yield return new WaitForSeconds(_waitBetweenActions);

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }

    public IEnumerator StartPlanet(int planetIndex)
    {
        if (!_loadingPlanet)
        {
            _loadingPlanet = true;
            Debug.Log("Start planet " + planetIndex);
            yield return new WaitForSeconds(_waitBetweenActions);
            _planetLoader.LoadPlanet(planetIndex + 1); // + 1 because there is the Menu scene at the position 0
            _loadingPlanet = false;
        }
    }
}
