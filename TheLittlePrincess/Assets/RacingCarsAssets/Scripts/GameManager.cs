using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public AIControls[] aiControls;
    public TricolorLights tricolorLights;

    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    
    private int restartCount = 0;
    private String betCar;
    private bool isBetCorrect = false;
    public UIManager ui;
    
    public PlayerController playerController;


    private void Start()
    {
        foreach (AIControls aiControl in aiControls)
        {
            Debug.Log(aiControl.transform.position);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            betCar = "Red";
            ui.UpdateText("Your bet is on red");
            StartGame("red");
        } else if (Input.GetKeyDown(KeyCode.G))
        {
            betCar = "Green";
            ui.UpdateText("Your bet is on green");
            StartGame("green");
        }
    }

    public void StartGame(string color)
    {
        ResetRace();
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(1);
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(2);
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(3);
        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        audioSource.PlayOneShot(highBeep);
        tricolorLights.SetProgress(4);
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }
    public void ResetRace()
    {
        int cpt = 0;
        foreach (AIControls aiControl in aiControls)
        {
            float  xPosition;
            if (restartCount == 0)
            {
                xPosition = 37.67f;
            }
            else
            {
                xPosition = 39f;
            }
            
            if (cpt == 0)
            {
                aiControl.transform.position = new Vector3(xPosition, 0.34f, -36.32f);
                cpt++;
            }
            else
            {
                aiControl.transform.position = new Vector3(xPosition, 0.34f, -30.22f);
            }
            aiControl.transform.rotation = new Quaternion(0, 90, 0, 0);
            aiControl.ResetFirstWaypoint();
        }
        restartCount++;
    }
    
    public void CheckBetResult(PlayerRank winner)
    {
        if (isBetCorrect = winner.identity.gameObject.tag == betCar)
        {
            ui.UpdateText("You won your bet ! You now have access to a new planet.");
        }
        else
        {
            ui.UpdateText("You lost! Try again.\nR : Bet on red car\nG : Bet on green car");
        }
    }

    public void LoadData(GameData data)
    {
        playerController.ChangePosition(data.playerPositionPlanet2);
    }

    public void SavaData(ref GameData data)
    {
        Debug.Log("isBetCorrect : " + isBetCorrect);
        if (data.planetLocked[2]) data.planetLocked[2] = !isBetCorrect;
        data.playerPositionPlanet2 = playerController.GetPosition();
    }
}
