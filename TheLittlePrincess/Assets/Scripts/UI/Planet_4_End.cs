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
    public AudioSource endSound;

    private float _waitBetweenActions = 0.7f;
    private AudioSource[] allAudioSources;

    private void Start()
    {
        Time.timeScale = 1f;
        _EndMenuController.DeActivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _EndMenuController.DeActivate();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            _EndMenuController.Activate();
            _baseUIController.DeActivate();
            StopAllAudio();
            endSound.enabled = true;
            Time.timeScale = 0f;
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
        Time.timeScale = 1f;
        yield return new WaitForSeconds(_waitBetweenActions);
        SceneManager.LoadScene(0);
    }

    private void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources) audioS.Stop();
    }

}
