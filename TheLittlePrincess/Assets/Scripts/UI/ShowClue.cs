using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowClue : IMenuController
{

    public string clue;
    public MenuButtonController _baseUIController, _showClueUIController, _clueUIController;
    public AudioSource enterClue, exitClue;
    public TMPro.TMP_Text clueUI;

    private bool showClue = false;
    private bool clueShown = false;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        _showClueUIController.DeActivate();
        _clueUIController.DeActivate();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            _clueUIController.Activate();
            showClue = true;
        }
        else 
        {
            _clueUIController.DeActivate();
            showClue = false;
        } 
    }

    void OnTriggerExit(Collider collider) 
    {
        _clueUIController.DeActivate();
        showClue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }

            _showClueUIController.DeActivate();
            _baseUIController.Activate();
            exitClue.Play();
            clueShown = false;

        }
        else if (Input.GetKeyDown(KeyCode.F) && showClue && !clueShown) {
            Time.timeScale = 0f;
            _baseUIController.DeActivate();
            _clueUIController.DeActivate();
            clueUI.text = clue;
            _showClueUIController.Activate();
            enterClue.Play();
            clueShown = true;
        } else if (Input.GetKeyDown(KeyCode.F) && showClue && clueShown)
        {
            Time.timeScale = 1f;
            _baseUIController.Activate();
            _showClueUIController.DeActivate();
            _clueUIController.Activate();
            AudioListener.pause = false;
            exitClue.Play();
            clueShown = false;
        }
    }

    override
    public void PressButton(int indexButton, string context)
    {
        Debug.Log("Nothing...");
    }
}
