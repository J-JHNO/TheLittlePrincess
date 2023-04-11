using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowClue : IMenuController
{

    public string clue;
    public MenuButtonController _baseUIController;
    public MenuButtonController _showClueUIController;
    public TMPro.TMP_Text clueUI;

    private bool showClue = false;
    private bool clueShown = false;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        _showClueUIController.DeActivate();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            showClue = true;
        }
        else showClue = false;
    }

    void OnTriggerExit(Collider collider) 
    {
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
            clueShown = false;

        }
        else if (Input.GetKeyDown(KeyCode.F) && showClue && !clueShown) {
            Time.timeScale = 0f;
            _baseUIController.DeActivate();
            clueUI.text = clue;
            _showClueUIController.Activate();
            clueShown = true;
        } else if (Input.GetKeyDown(KeyCode.F) && showClue && clueShown)
        {
            Time.timeScale = 1f;
            _baseUIController.Activate();
            _showClueUIController.DeActivate();
            clueShown = false;
        }
    }

    override
    public void PressButton(int indexButton, string context)
    {
        Debug.Log("Nothing...");
    }
}
