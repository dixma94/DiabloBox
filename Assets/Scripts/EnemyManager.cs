using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SpawnPointEnemy[] SpawnPoints;
    private SelectebleObjectsDictionary selectebleObjectsDictionary;
    public List<Rat> EnemyMap;

    [Inject]
    public void Construct(EnemyFactory factory, SelectebleObjectsDictionary selectebleObjectsDictionary)
    {
        factory.Load();
        this.selectebleObjectsDictionary = selectebleObjectsDictionary;
        foreach (var spawnPoint in SpawnPoints)
        {
            Rat rat = factory.Create(spawnPoint.transform.position);
            this.selectebleObjectsDictionary.AddToDictionary(rat);
        }
        
    }

}
