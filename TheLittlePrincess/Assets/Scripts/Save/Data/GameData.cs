using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int numberOfSave;
    public List<bool> planetLocked;
    public Vector3 playerPositionPlanet2;

    public GameData()
    {
        this.playerPositionPlanet2 = new Vector3(35.9324f, 2.090005f, -41.24332f);
        this.numberOfSave = 0;
        this.planetLocked = new List<bool>() { false, false, true, true };
    }
}
