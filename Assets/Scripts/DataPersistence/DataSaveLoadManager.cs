using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSaveLoadManager 
{


    private string FileName = "data.json";
    private GameData GameData;
    private List<IDataSaveLoad> DataPersistenceList;
    private FileDataHandler FileDataHandler;


    public DataSaveLoadManager()
    {
        this.FileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        DataPersistenceList = new List<IDataSaveLoad>();
        
    }

    public void NewGame()
    {
        this.GameData = new GameData();
    }

    public void LoadGame()
    {
        this.GameData = FileDataHandler.Load();
        if(this.GameData == null)
        {
            Debug.Log("No data found");
            NewGame();
        }
        foreach (IDataSaveLoad item in DataPersistenceList)
        {
            item.LoadData(GameData);
        }

    }
    public void SaveGame()
    {
        foreach (IDataSaveLoad item in DataPersistenceList)
        {
            item.SaveData( ref GameData);
        }
        FileDataHandler.Save(GameData);
    }

    public void AddDataPersistance(IDataSaveLoad dataPersistence)
    {
        DataPersistenceList.Add(dataPersistence);
    } 

}
