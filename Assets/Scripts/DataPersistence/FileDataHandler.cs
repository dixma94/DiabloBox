using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UIElements;

public class FileDataHandler 
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public GameData Load()
    {
        string fullPath = dataDirPath + "/" + dataFileName;
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try 
            {
                string dataToLoad = "";
                using (FileStream stream = new(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = dataDirPath + "/" + dataFileName;

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToSource = JsonUtility.ToJson(data,true);

            using (FileStream stream = new(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new(stream))
                {
                    writer.Write(dataToSource);
                }
            }

        }
        catch (Exception e)
        {

            Debug.LogError("Error occured when trying to save data to path: " + fullPath + "\n" + e);
        }
    }
}