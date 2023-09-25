using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class NPC_Manager : MonoBehaviour
{
    public Dictionary<NPCType, NPC> NpcMap;
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
            nPC.wayPointArray = spawnPoint.wayPointNPCs;
            nPC.spawnPoint = spawnPoint;
            this.selectebleObjectsDictionary.AddToDictionary(nPC);
        }
        questManager.UpdateState();
    }
    public NPC GetNpc(NPCType npcClass)
    {     
        return NpcMap[npcClass];       
    }
    public void AddNPC(NPC npc)
    {
        NpcMap.Add(npc.npcType, npc);
    }
}
