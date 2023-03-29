using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;

    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;

    void Awake()
    {
        StartGame();
    }
    public void StartGame()
    {
        FreezePlayers(true);
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
        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }
    public void StartRacing()
    {
        FreezePlayers(false);
    }
    void FreezePlayers(bool freeze)
    {
        //TODO : freeze players here
        
        foreach (AIControls aiC in this.aiControls)
        {
            aiC.enabled = !freeze;
        }
    }
}
