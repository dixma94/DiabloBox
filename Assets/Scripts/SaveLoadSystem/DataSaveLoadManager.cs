using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSaveLoadManager 
{


    private string FileName = "data.json";
    private GameData GameData;
    private List<IDataSave> DataObjectsList;
    private FileDataHandler FileDataHandler;


    public DataSaveLoadManager()
    {
        this.FileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        DataObjectsList = new List<IDataSave>();
        CreateNewGameData();
    }


    public GameData GetGameData()
    {
        if (this.GameData == null)
        {
            this.GameData = new GameData();
        }
        return GameData;
    }

    private void CreateNewGameData()
    {
        this.GameData = FileDataHandler.Load();
        if (this.GameData == null)
        {
            this.GameData = new GameData();
        }
    }

    public void SaveGame()
    {
        foreach (IDataSave item in DataObjectsList)
        {
            item.SaveData( ref GameData);
        }
        FileDataHandler.Save(GameData);
    }

    public void AddSaveDataObject(IDataSave dataObject)
    {
        DataObjectsList.Add(dataObject);
    } 

}
