using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUI : MonoBehaviour
{
    public int planetSceneNumber = 0;
    public PlanetLock planetLock;

    public MenuButton planetMenuButton;

    public int GetSceneNumber()
    {
        return this.planetSceneNumber;
    }

    public bool IsLocked()
    {
        return this.planetLock.IsLocked();
    }

    public void Lock()
    {
        this.planetLock.Lock();
    }

    public void Unlock()
    {
        this.planetLock.Unlock();
    }

    public void SetMenuButtonIndex(int index)
    {
        this.planetMenuButton.SetIndex(index);
    }
}
