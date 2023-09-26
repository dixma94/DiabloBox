using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField] private string FileName;


    private GameData GameData;
    public static DataPersistenceManager Instance;
    private List<IDataPersistence> DataPersistenceList;
    private FileDataHandler FileDataHandler;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        this.FileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        this.DataPersistenceList = FindAllDataPersistance();
        LoadGame();
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
        foreach (IDataPersistence item in DataPersistenceList)
        {
            item.LoadData(GameData);
        }

    }
    public void SaveGame()
    {
        foreach (IDataPersistence item in DataPersistenceList)
        {
            item.SaveData( ref GameData);
        }
        FileDataHandler.Save(GameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

     
    private List<IDataPersistence> FindAllDataPersistance()
    {
        IEnumerable<IDataPersistence> list = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(list);
    }
}
