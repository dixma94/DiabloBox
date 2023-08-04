using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    [SerializeField] private NPCInteractable[] NpcArray;

    static NPC_Manager instance;

    private void Awake()
    {
        instance = this; 
    }

    public static NPCInteractable GetNpc(NPC_Class npcClass)
    {
       
        return instance.NpcArray.FirstOrDefault(npc => npc.NPC_Class == npcClass);
       
    }
}
