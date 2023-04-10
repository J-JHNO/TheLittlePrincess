using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Planet_4_End : IMenuController
{
    public MenuButtonController _EndMenuController;
    public MenuButtonController _baseUIController;

    private bool end = false;
    private float _waitBetweenActions = 0.7f;

    private void Start()
    {
        Time.timeScale = 1f;
        _EndMenuController.DeActivate();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            _EndMenuController.Activate();
            _baseUIController.DeActivate();
            Time.timeScale = 0f;
            end = true;
        }
    }

    override
    public void PressButton(int indexButton, string context)
    {
        switch (indexButton)
        {
            case 0:
                StartCoroutine(BackToMainMenu());
                break;
        }
    }

    private IEnumerator BackToMainMenu()
    {
        Debug.Log("Back to main menu");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_waitBetweenActions);
        SceneManager.LoadScene(0);
    }
}
