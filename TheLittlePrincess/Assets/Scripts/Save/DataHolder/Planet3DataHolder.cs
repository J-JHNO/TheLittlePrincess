using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet3DataHolder : MonoBehaviour, IDataPersistence
{
    public PlayerController playerController;
    public DonnerEnigme donnerEnigme;

    public void LoadData(GameData data)
    {
        playerController.ChangePosition(data.playerPositionPlanet3);
    }

    public void SavaData(ref GameData data)
    {
        data.playerPositionPlanet3 = playerController.GetPosition();
        if (data.planetLocked[3]) data.planetLocked[3] = donnerEnigme.IsSolved();
    }
}
