using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    [SerializeField] private NPC[] NpcArray;

    static NPC_Manager instance;

    private void Awake()
    {
        instance = this; 
    }

    public static NPC GetNpc(NPCType npcClass)
    {
       
        return instance.NpcArray.FirstOrDefault(npc => npc.npcType == npcClass);
       
    }
}
