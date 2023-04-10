using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetLoader : MonoBehaviour, IDataPersistence
{
    public List<PlanetUI> planetUIs;
    public MenuButtonController planetMenuController;
    public List<MenuButton> otherPlanetMenuButton;

    public LoadingScreen loadingScreen;

    private List<bool> planetLocked;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        int nbUnlockedPlanet = NumberOfPlanetsUnlocked();
        this.planetMenuController.SetMaxIndex(nbUnlockedPlanet + otherPlanetMenuButton.Count - 1);
        InitPlanetUIs();
        InitPlanetButtonIndex();
        InitOtherPlanetMenuButtonIndex(nbUnlockedPlanet);
    }

    public void InitPlanetButtonIndex()
    {
        int currentIndex = 0;
        for (int i = 0; i < planetLocked.Count; i++)
        {
            if (planetLocked[i])
            {
                planetUIs[i].SetMenuButtonIndex(-1); // out of bound
            }
            else
            {
                planetUIs[i].SetMenuButtonIndex(currentIndex);
                currentIndex++;
            }
        }
    }

    public void InitOtherPlanetMenuButtonIndex(int nbUnlockedPlanet)
    {
        int currentIndex = nbUnlockedPlanet;
        for (int i = 0; i < otherPlanetMenuButton.Count; i++)
        {
            otherPlanetMenuButton[i].SetIndex(currentIndex);
            currentIndex++;
        }
    }

    public void InitPlanetUIs()
    {
        for (int i = 0; i < planetLocked.Count; i++)
        {
            if (planetLocked[i]) planetUIs[i].Lock();
            else planetUIs[i].Unlock();
        }
    }

    public int NumberOfPlanetsUnlocked()
    {
        int count = 0;
        for (int i=0; i < planetLocked.Count; i++)
        {
            if (!planetLocked[i]) count++;
        }

        return count;
    }

    public void LoadPlanet(int planetNumber)
    {
        PlanetUI planetUI = null;

        int unlockedIndex = 0;
        for (int i=0; i < planetUIs.Count; i++)
        {
            if (planetUIs[i].IsLocked()) continue;
            if (unlockedIndex == planetNumber)
            {
                planetUI = planetUIs[i];
                break;
            }
            unlockedIndex++;
        }

        
        if (planetUI != null && !planetUI.IsLocked())
        {
            int planetSceneNumber = planetUI.GetSceneNumber();
            Debug.Log("Start planet " + planetSceneNumber);
            loadingScreen.LoadScene(planetSceneNumber);
        }
        else
        {
            Debug.LogError("Can't load planet number " + planetUI.GetSceneNumber());
        }
    }

    public void UnlockAllPlanets()
    {
        for (int i=0; i < planetLocked.Count; i++)
        {
            planetLocked[i] = false;
        }

        Init();
    }

    public void LoadData(GameData data)
    {
        this.planetLocked = data.planetLocked;
    }

    public void SavaData(ref GameData data)
    {
        data.planetLocked = this.planetLocked;
    }
}
