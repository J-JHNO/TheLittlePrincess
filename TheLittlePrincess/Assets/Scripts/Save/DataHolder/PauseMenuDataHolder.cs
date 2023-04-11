using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuDataHolder : MonoBehaviour, IDataPersistence
{
    private int numberOfSave = 0;

    public void IncreaseNumberOfSave()
    {
        this.numberOfSave++;
    }

    public void LoadData(GameData data)
    {
        numberOfSave = data.numberOfSave;
    }

    public void SavaData(ref GameData data)
    {
        data.numberOfSave = numberOfSave;
    }
}
