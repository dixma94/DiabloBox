using System.Collections.Generic;
using UnityEngine;

public class SavePointsManager : IDataSave
{
    public Dictionary<int,SavePoint> points;
    public Vector3 currentSavePoint;

    public SavePointsManager(DataSaveLoadManager dataPersistenceManager)
    {
        dataPersistenceManager.AddSaveDataObject(this);
        currentSavePoint = dataPersistenceManager.GetGameData().heroSpawnPoint;
    }

    public void SaveData(ref GameData data)
    {
        if (currentSavePoint!=null)
        {
            data.heroSpawnPoint = currentSavePoint;
        }
        
        
    }
}