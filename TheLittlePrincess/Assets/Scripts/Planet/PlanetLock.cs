using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLock : MonoBehaviour
{
    public bool locked = true;

    public bool IsLocked()
    {
        return locked;
    }

    public void Lock()
    {
        this.locked = true;
        UpdateDisplay();
    }

    public void Unlock()
    {
        this.locked = false;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        this.gameObject.SetActive(this.locked);
    }
}
