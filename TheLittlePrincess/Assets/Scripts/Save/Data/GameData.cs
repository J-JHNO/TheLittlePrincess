using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int numberOfSave;
    public List<bool> planetLocked;

    public GameData()
    {
        this.numberOfSave = 0;
        this.planetLocked = new List<bool>() { false, false, true, true };
    }
}
