using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int ratsKilled;
    public Vector3 heroSpawnPoint;
    public GameData() 
    { 
        this.ratsKilled = 0;
        this.heroSpawnPoint = Vector3.zero; 
    }
}
