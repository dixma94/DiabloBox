using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int ratsKilled;
    public Vector3 heroSpawnPoint;
    public List<Quest> quests;
    public GameData() 
    { 
        this.ratsKilled = 0;
        this.heroSpawnPoint = Vector3.zero;
        this.quests = new List<Quest>();  
    }

    public void AddQuestToSave(Quest quest)
    {
        quests.Add(quest);
    }
}
