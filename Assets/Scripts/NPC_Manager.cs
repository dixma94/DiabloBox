using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class NPC_Manager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] SpawnPoints;
    private SelectebleObjectsDictionary selectebleObjectsDictionary;

    [Inject]
    public void Construct(NpcFactory factory, SelectebleObjectsDictionary selectebleObjectsDictionary, QuestManager questManager)
    {
        factory.Load();
        this.selectebleObjectsDictionary = selectebleObjectsDictionary;
        foreach (var spawnPoint in SpawnPoints)
        {
            NPC nPC = factory.Create(spawnPoint.npc_type, spawnPoint.transform.position);
            nPC.SetSpawnPoint(spawnPoint);
            this.selectebleObjectsDictionary.AddToDictionary(nPC); 
        }
        questManager.UpdateState();
    }

}
