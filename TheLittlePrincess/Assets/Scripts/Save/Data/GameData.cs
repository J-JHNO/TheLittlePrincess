using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int numberOfSave;
    public List<bool> planetLocked;
    public Vector3 playerPositionPlanet1;
    public Vector3 playerPositionPlanet2;
    public Vector3 playerPositionPlanet3;
    public Vector3 playerPositionPlanet4;

    public GameData()
    {
        this.numberOfSave = 0;
        this.planetLocked = new List<bool>() { false, false, true, true };
        this.playerPositionPlanet1 = new Vector3(0, 0, 0);
        this.playerPositionPlanet2 = new Vector3(35.9324f, 2.090005f, -41.24332f);
        this.playerPositionPlanet3 = new Vector3(0.4f, 2, -22.5f);
        this.playerPositionPlanet4 = new Vector3(500, 0, 100);
    }
}
