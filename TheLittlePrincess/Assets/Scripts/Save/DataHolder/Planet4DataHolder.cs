using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet4DataHolder : MonoBehaviour, IDataPersistence
{
    public PlayerController playerController;

    public void LoadData(GameData data)
    {
        playerController.ChangePosition(data.playerPositionPlanet4);
    }

    public void SavaData(ref GameData data)
    {
        data.playerPositionPlanet4 = playerController.GetPosition();
    }
}
