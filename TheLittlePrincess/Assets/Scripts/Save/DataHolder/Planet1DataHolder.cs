using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet1DataHolder : MonoBehaviour
{
    public PlayerController playerController;

    public void LoadData(GameData data)
    {
        playerController.ChangePosition(data.playerPositionPlanet1);
    }

    public void SavaData(ref GameData data)
    {
        data.playerPositionPlanet1 = playerController.GetPosition();
    }
}
