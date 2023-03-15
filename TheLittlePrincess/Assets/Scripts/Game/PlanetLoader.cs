using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetLoader : MonoBehaviour
{
    public void LoadPlanet(int planetNumber)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(planetNumber);
    }
}
